using BlazorMr.Database;
using BlazorMr.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorMr.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected MediaContext Context { get; }

    public Repository(MediaContext context)
    {
        Context = context;
    }

    protected DbSet<TEntity> Entity => Context.Set<TEntity>();

    public void Create(TEntity entity) => Entity.Add(entity);

    public TEntity? GetById(int id) => Entity.Find(id);
        
    public async Task<TEntity?> GetByIdAsync(int id) =>
        await Entity.FindAsync(id);

    public List<TEntity> GetAll() => Entity.ToList();

    public async Task<List<TEntity>> GetAllAsync() =>
        await Entity.ToListAsync();

    public async void Remove(int id)
    {
        TEntity? entity = await GetByIdAsync(id);

        if (entity is not null)
            Entity.Remove(entity);
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }
}