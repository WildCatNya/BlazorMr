using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IAuthorRepository Author { get; }

    public ITimeCodeRepository TimeCode { get; }

    public IVideoRepository Video { get; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}