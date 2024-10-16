using AutoMapper;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Extensions;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq.Expressions;


namespace iDoctor.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository,
                           IMapper mapper,
                           IPasswordService passwordService,
                           IUserRepository userRepository,
                           IEducationRepository educationRepository)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _userRepository = userRepository;
            _educationRepository = educationRepository;
        }

        public async Task<bool> RegisterAsync(RegisterDoctorDto model)
        {

            if (model.VerificationDocument == null || model.VerificationDocument.Length == 0) return false;

            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                HashedPassword = _passwordService.HashPassword(model.Password),
                Type = (int)UserTypes.Doctor,              
            };

            var fileName = $"{model.Email}_{model.VerificationDocument.FileName}";

            var relativePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            Directory.CreateDirectory(relativePath);

            var absolutePath = Path.Combine(relativePath, fileName);

            using (var stream = new FileStream(absolutePath, FileMode.Create))
            {
                await model.VerificationDocument.CopyToAsync(stream);
            }

            var doctor = new Doctor
            {
                User = user,
                IsVerified = true,
                VerificationDocumentPath = fileName
            };



            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveAsync();

            return true;
        }

        public async Task<List<ResultDoctorDto>> GetAllAsync(bool tracking = true)
        {
            var doctors = await _doctorRepository.GetAllAsync(tracking);
            return _mapper.Map<List<ResultDoctorDto>>(doctors);
        }

        public async Task<ResultDoctorDto> GetByIdAsync(int id, bool tracking = true)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id, tracking);

            if (doctor is null) return null;

            return _mapper.Map<ResultDoctorDto>(doctor);
        }

        public async Task<ResultDoctorDto> GetSingleAsync(Expression<Func<Doctor, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultDoctorDto>(await _doctorRepository.GetSingleAsync(method, tracking));
        }

        public async Task<List<ResultDoctorDto>> GetWhereAsync(Expression<Func<Doctor, bool>> method, bool tracking = true)
        {
            var doctors = await _doctorRepository.GetWhereAsync(method, tracking);

            return _mapper.Map<List<ResultDoctorDto>>(doctors);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            bool tracking = true;

            var doctor = await _doctorRepository.GetByIdAsync(id, tracking);

            if (doctor == null) return false;

            var verificationDocumentPath = doctor.VerificationDocumentPath;

            var user = doctor.User;

            if (user is null) return false;

            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", verificationDocumentPath);

            if (!string.IsNullOrEmpty(verificationDocumentPath) && File.Exists(absolutePath))
            {
                File.Delete(absolutePath);
            }

             _userRepository.Remove(user);
            await _userRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDoctorDto model)
        {

            bool tracking = true;

            var doctor = await _doctorRepository.GetByIdAsync(id, tracking);

            if (doctor == null) return false;

            string existingHashedPassword = doctor.User.HashedPassword;

            _mapper.Map(model, doctor);

            doctor.User.HashedPassword = existingHashedPassword;


            var existEducations = await _educationRepository.GetWhereAsync(e => e.DoctorId == id);

            if (existEducations is not null) _educationRepository.RemoveRange(existEducations);

            if (model.Image != null && model.Image.Length > 0)
            {
                var base64image = model.Image.ToBase64();
                doctor.User.Image = $"data:image/jpeg;base64,{base64image}";
            }

            _doctorRepository.Update(doctor);
        
            await _doctorRepository.SaveAsync();

            return true;
        }

        public async Task<bool> VerifyDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null) return false;

            doctor.IsVerified = true;
             _doctorRepository.Update(doctor);
            await _doctorRepository.SaveAsync();

            return true;
        }
    }
}
