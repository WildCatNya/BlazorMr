using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories.Interfaces;

public interface IUnitOfWork
{
    public IAuthorRepository Author { get; }

    public IVideoRepository Video { get; }
}