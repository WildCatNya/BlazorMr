using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IAuthorRepository AuthorRepository { get; }

    public ITimeCodeRepository TimeCodeRepository { get; }

    public IVideoRepository VideoRepository { get; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}