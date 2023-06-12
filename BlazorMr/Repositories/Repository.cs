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

    public virtual void Create(TEntity entity) => Entity.Add(entity);

    public virtual TEntity? GetById(int id) => Entity.Find(id);
        
    public virtual async Task<TEntity?> GetByIdAsync(int id) => await Entity.FindAsync(id);

    public virtual List<TEntity> GetAll() => Entity.ToList();

    public virtual async Task<List<TEntity>> GetAllAsync() => await Entity.ToListAsync();

    public virtual void Remove(int id)
    {
        TEntity? entity = GetById(id);

        if (entity is not null)
            Entity.Remove(entity);
    }

    public virtual void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public virtual void Update(TEntity entity) =>
        Context.Entry(entity).State = EntityState.Modified;
}