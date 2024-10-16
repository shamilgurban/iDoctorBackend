using AutoMapper;
using iDoctor.Application.Dtos.AppointmentDtos;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class AppointmentService:IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IPatientRepository _petientRepository;
        private readonly IMapper _mapper;

        public AppointmentService(IAppointmentRepository appointmentRepository,
                                   IMapper mapper,
                                   IPatientRepository petientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
            _petientRepository = petientRepository;
        }

        public async Task<bool> AcceptAppointmentAsync(int id)
        {
            var appointment =await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null) return false;

            appointment.Status = (int)AppointmentStatus.Accepted;

            _appointmentRepository.Update(appointment);
            await _appointmentRepository.SaveAsync();
            return true;
        }

        public async Task<bool> AddAsync(CreateAppointmentDto model)
        {
            if (model.AnalysisDocument == null || model.AnalysisDocument.Length == 0) return false;

            var appointments = _mapper.Map<Appointment>(model);

            var patient = await _petientRepository.GetByIdAsync(model.PatientId);

            if (patient is null) return false;  

            var fileName = $"{patient.User.Email}_{model.AnalysisDocument.FileName}";

            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);

            using (var stream = new FileStream(absolutePath, FileMode.Create))
            {
                await model.AnalysisDocument.CopyToAsync(stream);
            }

            appointments.AnalysisDocumentPath=fileName;
            appointments.Status = (int)AppointmentStatus.Pending;

            await _appointmentRepository.AddAsync(appointments);
            await _appointmentRepository.SaveAsync();

            return true;
        }

        public async Task<bool> DeclineAppointmentAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null) return false;

            appointment.Status = (int)AppointmentStatus.Declined;

            _appointmentRepository.Update(appointment);
            await _appointmentRepository.SaveAsync();
            return true;
        }

        public async Task<List<ResultAppointmentDto>> GetAllAsync(bool tracking = true)
        {

            var appointments = await _appointmentRepository.GetAllAsync();
            return _mapper.Map<List<ResultAppointmentDto>>(appointments);
        }

        public async Task<ResultAppointmentDto> GetByIdAsync(int id, bool tracking = true)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment is null) return null;

            return _mapper.Map<ResultAppointmentDto>(appointment);
        }

        public async Task<ResultAppointmentDto> GetSingleAsync(Expression<Func<Appointment, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultAppointmentDto>(await _appointmentRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultAppointmentDto>> GetWhereAsync(Expression<Func<Appointment, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultAppointmentDto>>(await _appointmentRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null) return false;

            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", appointment.AnalysisDocumentPath);

            if (!string.IsNullOrEmpty(appointment.AnalysisDocumentPath) && File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }

            _appointmentRepository.Remove(appointment);
            await _appointmentRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateAppointmentDto model)
        {
            var appointment = await _appointmentRepository.GetByIdAsync(id);

            if (appointment == null) return false;

            _mapper.Map(model, appointment);

            _appointmentRepository.Update(appointment);
            await _appointmentRepository.SaveAsync();

            return true;
        }
    }
}
