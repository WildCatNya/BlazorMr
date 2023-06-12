namespace BlazorMr.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : class
{
    public TEntity? GetById(int id);

    public Task<TEntity?> GetByIdAsync(int id);

    public List<TEntity> GetAll();

    public Task<List<TEntity>> GetAllAsync();

    public void Create(TEntity entity);

    public void Remove(int id);

    public void Remove(TEntity entity);
}