using BlazorMr.Database.Entities;

namespace BlazorMr.Repositories.Interfaces.EntityInterfaces;

public interface ITimeCodeRepository : IRepository<TimeCode>
{
    public List<TimeCode> GetAllWithIncludes();

    public Task<List<TimeCode>> GetAllWithIncludesAsync();
}