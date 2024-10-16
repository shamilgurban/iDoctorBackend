using iDoctor.Application.Dtos.MaritalStatusDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;


namespace iDoctor.Application.Services.Interfaces
{
    public interface IMaritalStatusService
    {
        Task<List<ResultMaritalStatusDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultMaritalStatusDto>> GetWhereAsync(Expression<Func<MaritalStatus, bool>> method, bool tracking = true);
        Task<ResultMaritalStatusDto> GetSingleAsync(Expression<Func<MaritalStatus, bool>> method, bool tracking = true);
        Task<ResultMaritalStatusDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateMaritalStatusDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateMaritalStatusDto model);
    }
}
