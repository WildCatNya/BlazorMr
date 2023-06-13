using BlazorMr.Database.Entities.Common;

namespace BlazorMr.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    public TEntity? GetById(int id, bool isNoTracking = false);

    public Task<TEntity?> GetByIdAsync(int id, bool isNoTracking = false);

    public List<TEntity> GetAll(bool isNoTracking = false);

    public Task<List<TEntity>> GetAllAsync(bool isNoTracking = false);

    public void Create(TEntity entity);

    public void Remove(int id);

    public void Remove(TEntity entity);

    public void Update(TEntity entity);

    public List<TEntity> Find(Func<TEntity, bool> predicate);
}