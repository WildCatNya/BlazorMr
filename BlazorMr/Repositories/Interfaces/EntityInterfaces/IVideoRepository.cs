using BlazorMr.Database.Entities;

namespace BlazorMr.Repositories.Interfaces.EntityInterfaces;

public interface IVideoRepository : IRepository<Video>
{
    public List<Video> GetAllWithIncludes();

    public Task<List<Video>> GetAllWithIncludesAsync();
}