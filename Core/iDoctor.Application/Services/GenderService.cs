using AutoMapper;
using iDoctor.Application.Dtos.GenderDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Services
{
    public class GenderService:IGenderService
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;
        public GenderService(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateGenderDto model)
        {
            await _genderRepository.AddAsync(_mapper.Map<Gender>(model));
            await _genderRepository.SaveAsync();
        }

        public async Task<List<ResultGenderDto>> GetAllAsync(bool tracking = true)
        {
            var genders = await _genderRepository.GetAllAsync();
            return _mapper.Map<List<ResultGenderDto>>(genders);
        }

        public async Task<ResultGenderDto> GetByIdAsync(int id, bool tracking = true)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            if (gender is null) return null;

            return _mapper.Map<ResultGenderDto>(gender);
        }

        public async Task<ResultGenderDto> GetSingleAsync(Expression<Func<Gender, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultGenderDto>(await _genderRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultGenderDto>> GetWhereAsync(Expression<Func<Gender, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultGenderDto>>(await _genderRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            if (gender == null) return false;

            await _genderRepository.RemoveAsync(gender);
            await _genderRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateGenderDto model)
        {
            var gender = await _genderRepository.GetByIdAsync(id);

            if (gender == null) return false;
            
            _mapper.Map(model, gender);

            await _genderRepository.UpdateAsync(gender);
            await _genderRepository.SaveAsync();

            return true;
        }
    }
}
