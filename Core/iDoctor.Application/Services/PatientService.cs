using AutoMapper;
using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Application.Extensions;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;
using System.Numerics;


namespace iDoctor.Application.Services
{
    public class PatientService:IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PatientService(IPatientRepository patientRepository,
                           IMapper mapper,
                           IPasswordService passwordService,
                           IUserRepository userRepository)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _userRepository = userRepository;
        }

        public async Task RegisterAsync(RegisterPatientDto model)
        {
           
            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                HashedPassword = _passwordService.HashPassword(model.Password),  
                Type = (int)UserTypes.Patient
            };


            var patient = new Patient{ User = user };

            await _patientRepository.AddAsync(patient);
            await _patientRepository.SaveAsync();  
        }

        public async Task<List<ResultPatientDto>> GetAllAsync(bool tracking = true)
        {
            var patients = await _patientRepository.GetAllAsync(tracking);
            return _mapper.Map<List<ResultPatientDto>>(patients);
        }

        public async Task<ResultPatientDto> GetByIdAsync(int id, bool tracking = true)
        {
            var patient = await _patientRepository.GetByIdAsync(id,tracking);

            if (patient is null) return null;
            
            return _mapper.Map<ResultPatientDto>(patient);
        }

        public async Task<ResultPatientDto> GetSingleAsync(Expression<Func<Patient, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultPatientDto>(await _patientRepository.GetSingleAsync(method,tracking));
        }

        public async Task<List<ResultPatientDto>> GetWhereAsync(Expression<Func<Patient, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultPatientDto>>(await _patientRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            bool tracking = true;

            var patient = await _patientRepository.GetByIdAsync(id,tracking);

            if (patient == null) return false;
            
            var user = patient.User;

            if (user is null) return false;
           
             _userRepository.Remove(user);
            await _userRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdatePatientDto model)
        {
                
            bool tracking = true;

            var patient = await _patientRepository.GetByIdAsync(id,tracking);

            if (patient == null) return false;
          

            string existingHashedPassword = patient.User.HashedPassword; 

            _mapper.Map(model, patient);

            patient.User.HashedPassword = existingHashedPassword;

            if (model.Image != null && model.Image.Length > 0)
            {
                var base64Image = model.Image.ToBase64();
                patient.User.Image = $"data:image/jpeg;base64,{base64Image}";
            }
          

             _patientRepository.Update(patient);
            await _patientRepository.SaveAsync();

            return true;
        }
    }
}
