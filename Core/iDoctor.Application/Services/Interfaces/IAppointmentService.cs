using iDoctor.Application.Dtos.AppointmentDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<ResultAppointmentDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultAppointmentDto>> GetWhereAsync(Expression<Func<Appointment, bool>> method, bool tracking = true);
        Task<ResultAppointmentDto> GetSingleAsync(Expression<Func<Appointment, bool>> method, bool tracking = true);
        Task<ResultAppointmentDto> GetByIdAsync(int id, bool tracking = true);
        Task<bool> AddAsync(CreateAppointmentDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateAppointmentDto model);
        Task<bool> AcceptAppointmentAsync(int id);
        Task<bool> DeclineAppointmentAsync(int id);
    }
}
