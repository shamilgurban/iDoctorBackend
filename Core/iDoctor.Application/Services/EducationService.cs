using AutoMapper;
using iDoctor.Application.Dtos.EducationDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class EducationService:IEducationService
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IMapper _mapper;
        public EducationService(IEducationRepository educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateEducationDto model)
        {
            await _educationRepository.AddAsync(_mapper.Map<Education>(model));
            await _educationRepository.SaveAsync();
        }

        public async Task<List<ResultEducationDto>> GetAllAsync(bool tracking = true)
        {
            var educations = await _educationRepository.GetAllAsync();
            return _mapper.Map<List<ResultEducationDto>>(educations);
        }

        public async Task<ResultEducationDto> GetByIdAsync(int id, bool tracking = true)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education is null) return null;

            return _mapper.Map<ResultEducationDto>(education);
        }

        public async Task<ResultEducationDto> GetSingleAsync(Expression<Func<Education, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultEducationDto>(await _educationRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultEducationDto>> GetWhereAsync(Expression<Func<Education, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultEducationDto>>(await _educationRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education == null) return false;

             _educationRepository.Remove(education);
            await _educationRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateEducationDto model)
        {
            var education = await _educationRepository.GetByIdAsync(id);

            if (education == null) return false;

            _mapper.Map(model, education);

             _educationRepository.Update(education);
            await _educationRepository.SaveAsync();

            return true;
        }
    }
}
