

using AutoMapper;
using iDoctor.Application.Dtos.MaritalStatusDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class MaritalStatusService:IMaritalStatusService
    {
        private readonly IMaritalStatusRepository _maritalStatusRepository;
        private readonly IMapper _mapper;
        public MaritalStatusService(IMaritalStatusRepository maritalStatusRepository, IMapper mapper)
        {
            _maritalStatusRepository = maritalStatusRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateMaritalStatusDto model)
        {
            await _maritalStatusRepository.AddAsync(_mapper.Map<MaritalStatus>(model));
            await _maritalStatusRepository.SaveAsync();
        }

        public async Task<List<ResultMaritalStatusDto>> GetAllAsync(bool tracking = true)
        {
            var maritalStatuses = await _maritalStatusRepository.GetAllAsync();
            return _mapper.Map<List<ResultMaritalStatusDto>>(maritalStatuses);
        }

        public async Task<ResultMaritalStatusDto> GetByIdAsync(int id, bool tracking = true)
        {
            var maritalStatus = await _maritalStatusRepository.GetByIdAsync(id);

            if (maritalStatus is null) return null;

            return _mapper.Map<ResultMaritalStatusDto>(maritalStatus);
        }

        public async Task<ResultMaritalStatusDto> GetSingleAsync(Expression<Func<MaritalStatus, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultMaritalStatusDto>(await _maritalStatusRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultMaritalStatusDto>> GetWhereAsync(Expression<Func<MaritalStatus, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultMaritalStatusDto>>(await _maritalStatusRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var maritalStatus = await _maritalStatusRepository.GetByIdAsync(id);

            if (maritalStatus == null) return false;

             _maritalStatusRepository.Remove(maritalStatus);
            await _maritalStatusRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMaritalStatusDto model)
        {
            var maritalStatus = await _maritalStatusRepository.GetByIdAsync(id);

            if (maritalStatus == null) return false;

            _mapper.Map(model, maritalStatus);

             _maritalStatusRepository.Update(maritalStatus);
            await _maritalStatusRepository.SaveAsync();

            return true;
        }
    }
}
