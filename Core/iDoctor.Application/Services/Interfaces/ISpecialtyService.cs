using iDoctor.Application.Dtos.SpecialtyDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;

namespace iDoctor.Application.Services.Interfaces
{
    public interface ISpecialtyService
    {
        Task<List<ResultSpecialtyDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultSpecialtyDto>> GetWhereAsync(Expression<Func<Specialty, bool>> method, bool tracking = true);
        Task<ResultSpecialtyDto> GetSingleAsync(Expression<Func<Specialty, bool>> method, bool tracking = true);
        Task<ResultSpecialtyDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateSpecialtyDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateSpecialtyDto model);
    }
}
