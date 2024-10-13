
using AutoMapper;
using iDoctor.Application.Dtos.SpecialtyDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;


namespace iDoctor.Application.Services
{
    public class SpecialtyService:ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMapper _mapper;
        public SpecialtyService(ISpecialtyRepository specialtyRepository, IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateSpecialtyDto model)
        {
            await _specialtyRepository.AddAsync(_mapper.Map<Specialty>(model));
            await _specialtyRepository.SaveAsync();
        }

        public async Task<List<ResultSpecialtyDto>> GetAllAsync(bool tracking = true)
        {
            var specialties = await _specialtyRepository.GetAllAsync();
            return _mapper.Map<List<ResultSpecialtyDto>>(specialties);
        }

        public async Task<ResultSpecialtyDto> GetByIdAsync(int id, bool tracking = true)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if (specialty is null) return null;
          
            return _mapper.Map<ResultSpecialtyDto>(specialty);
        }

        public async Task<ResultSpecialtyDto> GetSingleAsync(Expression<Func<Specialty, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultSpecialtyDto>(await _specialtyRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultSpecialtyDto>> GetWhereAsync(Expression<Func<Specialty, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultSpecialtyDto>>(await _specialtyRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if (specialty == null) return false;
         
             _specialtyRepository.Remove(specialty);
            await _specialtyRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateSpecialtyDto model)
        {
            var specialty = await _specialtyRepository.GetByIdAsync(id);

            if (specialty == null) return false;
        
            _mapper.Map(model, specialty);

             _specialtyRepository.Update(specialty);
            await _specialtyRepository.SaveAsync();

            return true;
        }
    }
}
