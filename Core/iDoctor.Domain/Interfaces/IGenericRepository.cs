using iDoctor.Domain.Entities.Common;
using System.Linq.Expressions;


namespace iDoctor.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        public Task AddAsync(T model);

        public Task<List<T>> GetAllAsync(bool tracking = true, params Expression<Func<T, object>>[] includes);

        public Task<T> GetByIdAsync(int id, bool tracking = true, params Expression<Func<T, object>>[] includes);

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, params Expression<Func<T, object>>[] includes);

        public Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true, params Expression<Func<T, object>>[] includes);

        public Task RemoveAsync(T model);
        public  Task UpdateAsync(T model);
        public Task SaveAsync();
    }
}
