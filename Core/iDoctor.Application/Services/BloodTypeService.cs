using AutoMapper;
using iDoctor.Application.Dtos.BloodTypeDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class BloodTypeService:IBloodTypeService
    {
        private readonly IBloodTypeRepository _bloodTypeRepository;
        private readonly IMapper _mapper;
        public BloodTypeService(IBloodTypeRepository bloodTypeRepository, IMapper mapper)
        {
            _bloodTypeRepository = bloodTypeRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateBloodTypeDto model)
        {
            await _bloodTypeRepository.AddAsync(_mapper.Map<BloodType>(model));
            await _bloodTypeRepository.SaveAsync();
        }

        public async Task<List<ResultBloodTypeDto>> GetAllAsync(bool tracking = true)
        {
            var bloodTypes = await _bloodTypeRepository.GetAllAsync();
            return _mapper.Map<List<ResultBloodTypeDto>>(bloodTypes);
        }

        public async Task<ResultBloodTypeDto> GetByIdAsync(int id, bool tracking = true)
        {
            var bloodType = await _bloodTypeRepository.GetByIdAsync(id);

            if (bloodType is null) return null;

            return _mapper.Map<ResultBloodTypeDto>(bloodType);
        }

        public async Task<ResultBloodTypeDto> GetSingleAsync(Expression<Func<BloodType, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultBloodTypeDto>(await _bloodTypeRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultBloodTypeDto>> GetWhereAsync(Expression<Func<BloodType, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultBloodTypeDto>>(await _bloodTypeRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var bloodType = await _bloodTypeRepository.GetByIdAsync(id);

            if (bloodType == null) return false;

             _bloodTypeRepository.Remove(bloodType);
            await _bloodTypeRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateBloodTypeDto model)
        {
            var bloodType = await _bloodTypeRepository.GetByIdAsync(id);

            if (bloodType == null) return false;

            _mapper.Map(model, bloodType);

             _bloodTypeRepository.Update(bloodType);
            await _bloodTypeRepository.SaveAsync();

            return true;
        }
    }
}
