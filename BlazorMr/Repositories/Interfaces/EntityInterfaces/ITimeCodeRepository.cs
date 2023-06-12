using BlazorMr.Database.Entities;

namespace BlazorMr.Repositories.Interfaces.EntityInterfaces;

public interface ITimeCodeRepository
{
    public List<TimeCode> GetAllWithIncludes();

    public Task<List<TimeCode>> GetAllWithIncludesAsync();
}