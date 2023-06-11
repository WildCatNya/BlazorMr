namespace BlazorMr.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public Task<TEntity?> Get(int id);

    public Task<List<TEntity>> GetAll();

    public void Create(TEntity entity);

    public void Remove(int id);

    public void Remove(TEntity entity);
}