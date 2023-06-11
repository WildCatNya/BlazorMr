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

    public void Create(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<TEntity?> Get(int id) =>
        await Context.Set<TEntity>().FindAsync(id);

    public async Task<List<TEntity>> GetAll() =>
        await Context.Set<TEntity>().ToListAsync();

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }
}