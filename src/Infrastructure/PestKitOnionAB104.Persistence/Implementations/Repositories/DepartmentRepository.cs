using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Domain.Entities;
using PestKitOnionAB104.Persistence.Contexts;
using PestKitOnionAB104.Persistence.Implementations.Repositories.Generic;

namespace PestKitOnionAB104.Persistence.Implementations.Repositories
{
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        public DepartmentRepository(AppDbContext context):base(context)
        {

        }
    }
}
