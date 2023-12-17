using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WorldLeague.Entities.Shared;

namespace WorldLeague.Repository;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
{
    public readonly DbSet<TEntity> _entities;
    protected readonly DbContext _dbContext;
    protected GenericRepository(DbContext context)
    {
        _entities = context.Set<TEntity>();
        _dbContext = context;
    }
    public async Task<List<TEntity>> AllAsync(bool isActive = true)
    {
        return await _entities.Where(s => s.IsActive == isActive).AsQueryable().ToListAsync();
    }
     

    public async Task<TEntity> GetByIdAsync(int id, bool isActive = true)
    {
        return await _entities.SingleOrDefaultAsync(s => s.Id == id && s.IsActive == isActive);
    }

    public async Task SaveAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
}
