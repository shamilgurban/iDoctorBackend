using AutoMapper;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Extensions;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using Microsoft.Extensions.Hosting;
using System.Linq.Expressions;


namespace iDoctor.Application.Services
{
    public class DoctorService:IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUserRepository _userRepository;
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IMapper _mapper;

        public DoctorService(IDoctorRepository doctorRepository,
                           IMapper mapper,
                           IPasswordService passwordService,
                           IUserRepository userRepository,
                           IHostEnvironment hostEnvironment)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _userRepository = userRepository;
            _hostEnvironment = hostEnvironment;
        }

        public async Task<bool> RegisterAsync(RegisterDoctorDto model)
        {

            if(model.VerificationDocument==null || model.VerificationDocument.Length==0) return false;

            var user = new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                HashedPassword = _passwordService.HashPassword(model.Password),
                Type = (int)UserTypes.Doctor
            };

            var fileName = $"{model.Email}_{model.VerificationDocument.FileName}";
            var relativePath = Path.Combine("wwwroot", fileName);

            var absolutePath = Path.Combine(Directory.GetCurrentDirectory(), relativePath);

            using (var stream = new FileStream(absolutePath, FileMode.Create))
            {
                await model.VerificationDocument.CopyToAsync(stream);
            }

            var doctor = new Doctor
            {
                User = user,
                IsVerified = false,
                VerificationDocumentPath=relativePath
            };

          

            await _doctorRepository.AddAsync(doctor);
            await _doctorRepository.SaveAsync();

            return true;
        }

        public async Task<List<ResultDoctorDto>> GetAllAsync(bool tracking = true)
        {
            var doctors = await _doctorRepository.GetAllAsync(tracking, d => d.User);
            return _mapper.Map<List<ResultDoctorDto>>(doctors);
        }

        public async Task<ResultDoctorDto> GetByIdAsync(int id, bool tracking = true)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id, tracking, d => d.User);

            if (doctor is null) return null;
       
            return _mapper.Map<ResultDoctorDto>(doctor);
        }

        public async Task<ResultDoctorDto> GetSingleAsync(Expression<Func<Doctor, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultDoctorDto>(await _doctorRepository.GetSingleAsync(method, tracking, p => p.User));
        }

        public async Task<List<ResultDoctorDto>> GetWhereAsync(Expression<Func<Doctor, bool>> method, bool tracking = true)
        {
            var doctors = await _doctorRepository.GetWhereAsync(method,tracking,d=>d.User);

            return _mapper.Map<List<ResultDoctorDto>>(doctors);
        }

        public async Task<bool> RemoveAsync(int id)
        {
            bool tracking = true;

            var doctor = await _doctorRepository.GetByIdAsync(id, tracking, p => p.User);

            if (doctor == null) return false;

            var verificationDocumentPath = doctor.VerificationDocumentPath;

            var user = doctor.User;

            if (user is null) return false;

            if (!string.IsNullOrEmpty(verificationDocumentPath) && File.Exists(verificationDocumentPath))
            {
                File.Delete(verificationDocumentPath);
            }

            await _userRepository.RemoveAsync(user);
            await _userRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateDoctorDto model)
        {

            bool tracking = true;

            var doctor = await _doctorRepository.GetByIdAsync(id, tracking, p => p.User);

            if (doctor == null) return false;
         
            string existingHashedPassword = doctor.User.HashedPassword;

            _mapper.Map(model, doctor);

            doctor.User.HashedPassword = existingHashedPassword;

            if (model.Image != null && model.Image.Length > 0)
            {
                var base64Image = model.Image.ToBase64();
                doctor.User.Image = $"data:image/jpeg;base64,{base64Image}";
            }

            await _doctorRepository.UpdateAsync(doctor);
            await _doctorRepository.SaveAsync();

            return true;
        }

        public async Task<bool> VerifyDoctorAsync(int id)
        {
            var doctor = await _doctorRepository.GetByIdAsync(id);

            if (doctor == null) return false;

            doctor.IsVerified = true;
            await _doctorRepository.UpdateAsync(doctor);
            await _doctorRepository.SaveAsync();

            return true;
        }
    }
}
