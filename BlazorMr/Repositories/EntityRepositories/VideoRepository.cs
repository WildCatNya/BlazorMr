using BlazorMr.Database;
using BlazorMr.Database.Entities;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BlazorMr.Repositories.EntityRepositories;

public class VideoRepository : Repository<Video>, IVideoRepository
{
    public VideoRepository(MediaContext context) : base(context) { }

    public List<Video> GetAllWithIncludes() =>
        Entity.Include(x => x.TimeCodes).Include(x => x.IdAuthorNavigation).ToList();

    public async Task<List<Video>> GetAllWithIncludesAsync() =>
        await Entity.Include(x => x.TimeCodes).Include(x => x.IdAuthorNavigation).ToListAsync();
}