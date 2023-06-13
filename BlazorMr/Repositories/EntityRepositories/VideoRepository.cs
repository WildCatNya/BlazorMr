using BlazorMr.Database;
using BlazorMr.Database.Entities;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BlazorMr.Repositories.EntityRepositories;

public class VideoRepository : Repository<Video>, IVideoRepository
{
    private readonly IIncludableQueryable<Video, Author> _entityWithIncludes;

    public VideoRepository(MediaContext context) : base(context)
    {
        _entityWithIncludes = Entity.Include(x => x.TimeCodes).Include(x => x.IdAuthorNavigation);
    }

    public List<Video> GetAllWithIncludes(bool isNoTracking = false)
    {
        if (isNoTracking)
            return _entityWithIncludes.AsNoTracking().ToList();

        return _entityWithIncludes.ToList();
    }

    public async Task<List<Video>> GetAllWithIncludesAsync(bool isNoTracking = false)
    {
        if (isNoTracking)
            return await _entityWithIncludes.AsNoTracking().ToListAsync();

        return await _entityWithIncludes.ToListAsync();
    }

    public List<Video> FindWithIncludes(Func<Video, bool> predicate, bool isNoTracking = false)
    {
        if (isNoTracking)
            return _entityWithIncludes.AsNoTracking().Where(predicate).ToList();

        return _entityWithIncludes.Where(predicate).ToList();
    }
}