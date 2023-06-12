using BlazorMr.Database;
using BlazorMr.Database.Entities;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BlazorMr.Repositories.EntityRepositories;

public class TimeCodeRepository : Repository<TimeCode>, ITimeCodeRepository
{
    public TimeCodeRepository(MediaContext context) : base(context) { }

    public List<TimeCode> GetAllWithIncludes() =>
        Entity.Include(x => x.IdVideoNavigation).ToList();

    public async Task<List<TimeCode>> GetAllWithIncludesAsync() =>
        await Entity.Include(x => x.IdVideoNavigation).ToListAsync();
}