using BlazorMr.Database.Entities;

namespace BlazorMr.Repositories.Interfaces.EntityInterfaces;

public interface IVideoRepository : IRepository<Video>
{
    public List<Video> GetAllWithIncludes(bool isNoTracking = false);

    public Task<List<Video>> GetAllWithIncludesAsync(bool isNoTracking = false);

    public List<Video> FindWithIncludes(Func<Video, bool> predicate, bool isNoTracking = false);
}