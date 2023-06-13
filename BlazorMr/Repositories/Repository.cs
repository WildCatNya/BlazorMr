using BlazorMr.Database;
using BlazorMr.Database.Entities.Common;
using BlazorMr.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorMr.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    protected MediaContext Context { get; }

    public Repository(MediaContext context)
    {
        Context = context;
    }

    protected DbSet<TEntity> Entity => Context.Set<TEntity>();

    protected IQueryable<TEntity> NoTrackingEntity => Entity.AsNoTracking();

    public virtual void Create(TEntity entity) => Entity.Add(entity);

    public virtual TEntity? GetById(int id, bool isNoTracking = false)
    {
        if (isNoTracking)
            return NoTrackingEntity.FirstOrDefault(x => x.Id == id);

        return Entity.Find(id);
    }

    public virtual async Task<TEntity?> GetByIdAsync(int id, bool isNoTracking = false)
    {
        if (isNoTracking)
            return await NoTrackingEntity.FirstOrDefaultAsync(x => x.Id == id);

        return await Entity.FindAsync(id);
    }

    public virtual List<TEntity> GetAll(bool isNoTracking = false)
    {
        if (isNoTracking)
            return NoTrackingEntity.ToList();

        return Entity.ToList();
    }

    public virtual async Task<List<TEntity>> GetAllAsync(bool isNoTracking = false)
    {
        if (isNoTracking)
            return await NoTrackingEntity.ToListAsync();

        return await Entity.ToListAsync();
    }

    public virtual void Remove(int id)
    {
        TEntity? entity = GetById(id);

        if (entity is not null)
            Entity.Remove(entity);
    }

    public virtual void Remove(TEntity entity) => Remove(entity.Id);

    public virtual void Update(TEntity entity) =>
        Context.Entry(entity).State = EntityState.Modified;

    public List<TEntity> Find(Func<TEntity, bool> predicate)
    {
        return Entity.Where(predicate).ToList();
    }
}