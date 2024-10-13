using iDoctor.Domain.Entities.Common;
using System.Linq.Expressions;


namespace iDoctor.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task AddAsync(T model);
        Task AddRangeAsync(List<T> models);
        Task<List<T>> GetAllAsync(bool tracking = true, params Expression<Func<T, object>>[] includes);

        Task<T> GetByIdAsync(int id, bool tracking = true, params Expression<Func<T, object>>[] includes);

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true, params Expression<Func<T, object>>[] includes);

        Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> method, bool tracking = true, params Expression<Func<T, object>>[] includes);
        void Remove(T model);
        void RemoveRange(List<T> models);
        void Update(T model);
        Task SaveAsync();
    }
}
