using BlazorMr.Database;
using BlazorMr.Repositories.EntityRepositories;
using BlazorMr.Repositories.Interfaces;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MediaContext _context;

    public IAuthorRepository AuthorRepository { get; }

    public ITimeCodeRepository TimeCodeRepository { get; }

    public IVideoRepository VideoRepository { get; }

    public UnitOfWork(MediaContext context)
    {
        _context = context;

        AuthorRepository = new AuthorRepository(context);

        TimeCodeRepository = new TimeCodeRepository(context);

        VideoRepository = new VideoRepository(context);
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