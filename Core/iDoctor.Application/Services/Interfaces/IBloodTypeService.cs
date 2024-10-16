

using iDoctor.Application.Dtos.BloodTypeDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IBloodTypeService
    {
        Task<List<ResultBloodTypeDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultBloodTypeDto>> GetWhereAsync(Expression<Func<BloodType, bool>> method, bool tracking = true);
        Task<ResultBloodTypeDto> GetSingleAsync(Expression<Func<BloodType, bool>> method, bool tracking = true);
        Task<ResultBloodTypeDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateBloodTypeDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateBloodTypeDto model);
    }
}
