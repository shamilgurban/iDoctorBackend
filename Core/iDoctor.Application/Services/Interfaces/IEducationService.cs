using iDoctor.Application.Dtos.EducationDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;


namespace iDoctor.Application.Services.Interfaces
{
    public interface IEducationService
    {
        Task<List<ResultEducationDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultEducationDto>> GetWhereAsync(Expression<Func<Education, bool>> method, bool tracking = true);
        Task<ResultEducationDto> GetSingleAsync(Expression<Func<Education, bool>> method, bool tracking = true);
        Task<ResultEducationDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateEducationDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateEducationDto model);
     
    }
}
