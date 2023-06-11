using BlazorMr.Database;
using BlazorMr.Database.Entities;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories.EntityRepositories;

public class VideoRepository : Repository<Video>, IVideoRepository
{
    public VideoRepository(MediaContext context) : base(context) { }
}