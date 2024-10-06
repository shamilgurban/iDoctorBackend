using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;


namespace iDoctor.Application.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<ResultPatientDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultPatientDto>> GetWhereAsync(Expression<Func<Patient, bool>> method, bool tracking = true);
        Task<ResultPatientDto> GetSingleAsync(Expression<Func<Patient, bool>> method, bool tracking = true);
        Task<ResultPatientDto> GetByIdAsync(int id, bool tracking = true);
        Task RegisterAsync(RegisterPatientDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdatePatientDto model);
    }
}
