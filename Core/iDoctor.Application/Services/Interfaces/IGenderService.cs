using iDoctor.Application.Dtos.GenderDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IGenderService
    {
        Task<List<ResultGenderDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultGenderDto>> GetWhereAsync(Expression<Func<Gender, bool>> method, bool tracking = true);
        Task<ResultGenderDto> GetSingleAsync(Expression<Func<Gender, bool>> method, bool tracking = true);
        Task<ResultGenderDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateGenderDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateGenderDto model);
    }
}
