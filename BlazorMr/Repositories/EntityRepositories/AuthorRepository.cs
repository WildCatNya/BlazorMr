using BlazorMr.Database;
using BlazorMr.Database.Entities;
using BlazorMr.Repositories.Interfaces.EntityInterfaces;

namespace BlazorMr.Repositories.EntityRepositories;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(MediaContext context) : base(context) { }
}