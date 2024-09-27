using iDoctor.Domain.Entities.Common;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace iDoctor.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T model)
        {
            await Table.AddAsync(model);
            await SaveAsync();
        }

        public async Task<List<T>> GetAllAsync(bool tracking = true)
        {        
            var query =await Table.ToListAsync();
            if (!tracking)
                query = await Table.AsNoTracking().ToListAsync(); ;
            return query;
        }

        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query =await Table.Where(method).ToListAsync();
            if (!tracking)
                query = await Table.AsNoTracking().Where(method).ToListAsync();
            return query;
        }

        public async Task RemoveAsync(T model)
        {
            Table.Remove(model);
            await SaveAsync();
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();

        public async Task UpdateAsync(T model)
        {
           Table.Update(model);
           await SaveAsync();
        }
    }
}
