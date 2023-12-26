using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Domain.Entities;
using PestKitOnionAB104.Persistence.Contexts;
using PestKitOnionAB104.Persistence.Implementations.Repositories.Generic;

namespace PestKitOnionAB104.Persistence.Implementations.Repositories
{
    internal class AuthorRepository : Repository<Author>,IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {

        }
    }
}
