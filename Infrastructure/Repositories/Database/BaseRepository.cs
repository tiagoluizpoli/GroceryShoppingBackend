using System.Data;
using System.Linq.Expressions;
using Application.Repositories.Database;
using Domain.EFSetup;
using Domain.EFSetup.Entities;
using Domain.Errors.Errors.DatabaseErrors;
using EntityFramework.Exceptions.Common;
using ErrorOr;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repositories.Database;

public class BaseRepository<EntityType> : IBaseRepository<EntityType> where EntityType : class
{
    private readonly EFDbContext _context;
    private readonly DbSet<EntityType> _dbSet;

    public BaseRepository(EFDbContext context)
    {
        _context = context;
        _dbSet = context.Set<EntityType>();
    }

    public async Task<ErrorOr<Created>> Add(EntityType obj)
    {
        try
        {
            await _dbSet.AddAsync(obj);
            await _context.SaveChangesAsync();
            return Result.Created;
        }
        catch (InvalidOperationException ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
        catch (UniqueConstraintException ex)
        {
            return DatabaseErrors.Entity.UniqueConstraint(ex);
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public async Task<ErrorOr<Deleted>> Delete(EntityType obj)
    {
        try
        {
            _dbSet.Remove(obj);
            await _context.SaveChangesAsync();
            return Result.Deleted;
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public async Task<ErrorOr<Updated>> Update(EntityType obj)
    {
        try
        {
            _dbSet.Update(obj);
            await _context.SaveChangesAsync();
            return Result.Updated;
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public async Task<ErrorOr<EntityType?>> GetById(Guid Id)
    {
        try
        {
            EntityType response = await _dbSet.FindAsync(Id);
            if (response is null)
            {
                return DatabaseErrors.Entity.NotFound<ProductEntity>(Id.ToString());
            }

            return response;
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public async Task<ErrorOr<List<EntityType>>> GetAll(Expression<Func<EntityType, bool>> filter = null,
        string includeProperties = "")
    {
        try
        {
            IQueryable<EntityType> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' },
                             StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return await query.ToListAsync();
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }
}