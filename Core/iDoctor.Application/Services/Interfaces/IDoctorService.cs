using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;


namespace iDoctor.Application.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<ResultDoctorDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultDoctorDto>> GetWhereAsync(Expression<Func<Doctor, bool>> method, bool tracking = true);
        Task<ResultDoctorDto> GetSingleAsync(Expression<Func<Doctor, bool>> method, bool tracking = true);
        Task<ResultDoctorDto> GetByIdAsync(int id, bool tracking = true);
        Task<bool> RegisterAsync(RegisterDoctorDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateDoctorDto model);
        Task<bool> VerifyDoctorAsync(int id);
    }
}
