using System.Data;
using Application.Repositories.Database;
using Domain.EFSetup;
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

    public ErrorOr<Deleted> Delete(EntityType obj)
    {
        try
        {
            _dbSet.Remove(obj);
            _context.SaveChanges();
            return Result.Deleted;
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public ErrorOr<Updated> Update(EntityType obj)
    {
        try
        {
            _dbSet.Update(obj);
            _context.SaveChanges();
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
            return await _dbSet.FindAsync(Id);
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }

    public async Task<ErrorOr<List<EntityType>>> GetAll()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            return DatabaseErrors.General.DatabaseGeneralError(ex);
        }
    }
}