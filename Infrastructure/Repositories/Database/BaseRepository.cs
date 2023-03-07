using Application.Repositories.Database;
using Domain.EFSetup;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Database;

public class BaseRepository<EntityType> : IBaseRepository<EntityType> where EntityType : class
{
    protected readonly EFDbContext _context;
    protected readonly DbSet<EntityType> _dbSet;

    public BaseRepository(EFDbContext context)
    {
        _context = context;
        _dbSet = context.Set<EntityType>();
    }

    public void Add(EntityType obj)
    {
        _dbSet.Add(obj);
        _context.SaveChanges();
    }

    public void Delete(EntityType obj)
    {
        _dbSet.Remove(obj);
        _context.SaveChanges();
    }

    public void Update(EntityType obj)
    {
        _dbSet.Update(obj);
        _context.SaveChanges();
    }

    public async Task<EntityType?> GetById(Guid Id)
    {
        return await _dbSet.FindAsync(Id);
    }

    public async Task<List<EntityType>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }
}