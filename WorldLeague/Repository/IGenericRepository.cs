using System.Linq.Expressions;
using WorldLeague.Entities.Shared;

namespace WorldLeague.Repository;

public interface IGenericRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(int id, bool isActive = true);
    Task<List<TEntity>> AllAsync(bool isActive = true);
    Task SaveAsync(TEntity entity);
}
