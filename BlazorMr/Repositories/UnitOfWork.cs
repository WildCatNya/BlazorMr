using BlazorMr.Database;
using BlazorMr.Repositories.EntityRepositories;
using BlazorMr.Repositories.Interfaces;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MediaContext _context;

    public IAuthorRepository Author { get; }

    public IVideoRepository Video { get; }

    public UnitOfWork(MediaContext context)
    {
        _context = context;

        Author = new AuthorRepository(context);

        Video = new VideoRepository(context);
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}