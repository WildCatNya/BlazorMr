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

    public int SaveChanges() => _context.SaveChanges();

    public async Task<int> SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    private bool _disposed = false;

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}