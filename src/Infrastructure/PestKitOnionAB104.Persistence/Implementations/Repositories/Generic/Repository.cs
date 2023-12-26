using Microsoft.EntityFrameworkCore;
using PestKitOnionAB104.Application.Abstractions.Repositories;
using PestKitOnionAB104.Domain;
using PestKitOnionAB104.Persistence.Contexts;
using System.Linq.Expressions;

namespace PestKitOnionAB104.Persistence.Implementations.Repositories.Generic
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _table = context.Set<T>();
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await _table.FirstOrDefaultAsync(c => c.Id == id);
            return entity;
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public void SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            _table.Update(entity);
        }
        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll(bool IsTracking = true, bool isDeleted = false, params string[] includes)
        {
            IQueryable<T> query = _table;

            query = _addIncludes(query, includes);

            if (isDeleted) query = query.IgnoreQueryFilters();

            return IsTracking ? query : query.AsNoTracking();
        }

        public IQueryable<T> GetAllWhere(Expression<Func<T, bool>>? expression = null, Expression<Func<T, object>>? orderExpression = null, bool IsDescending = false, int skip = 0, int take = 0, bool IsTracking = true, bool isDeleted = false, params string[] includes)
        {
            var query = _table.AsQueryable();

            if (expression is not null)
            {
                query = query.Where(expression);
            }

            if (orderExpression is not null)
            {
                if (IsDescending) query = query.OrderByDescending(orderExpression);
                else query = query.OrderBy(orderExpression);
            }

            if (skip != 0) query = query.Skip(skip);

            if (take != 0) query = query.Take(take);

            query = _addIncludes(query, includes);

            if (isDeleted) query = query.IgnoreQueryFilters();
            return IsTracking ? query : query.AsNoTracking();
        }
        public async Task<T> GetByIdAsync(int id, bool IsTarcking = true, bool isDeleted = false, params string[] includes)
        {
            IQueryable<T> query = _table.Where(x => x.Id == id);

            query = _addIncludes(query, includes);

            if (!IsTarcking) query = query.AsNoTracking();

            if (isDeleted) query = query.IgnoreQueryFilters();

            return await query.FirstOrDefaultAsync();
        }
        private IQueryable<T> _addIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }

    }
}
