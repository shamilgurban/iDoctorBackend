using AutoMapper;
using iDoctor.Application.Dtos.AnalysisDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class AnalysisService:IAnalysisService
    {
        private readonly IAnalysisRepository _analysisRepository;
        private readonly IMapper _mapper;
        public AnalysisService(IAnalysisRepository analysisRepository, IMapper mapper)
        {
            _analysisRepository = analysisRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateAnalysisDto model)
        {
            await _analysisRepository.AddAsync(_mapper.Map<Analysis>(model));
            await _analysisRepository.SaveAsync();
        }

        public async Task<List<ResultAnalysisDto>> GetAllAsync(bool tracking = true)
        {
            var analyses = await _analysisRepository.GetAllAsync();
            return _mapper.Map<List<ResultAnalysisDto>>(analyses);
        }

        public async Task<ResultAnalysisDto> GetByIdAsync(int id, bool tracking = true)
        {
            var analysis = await _analysisRepository.GetByIdAsync(id);

            if (analysis is null) return null;

            return _mapper.Map<ResultAnalysisDto>(analysis);
        }

        public async Task<ResultAnalysisDto> GetSingleAsync(Expression<Func<Analysis, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultAnalysisDto>(await _analysisRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultAnalysisDto>> GetWhereAsync(Expression<Func<Analysis, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultAnalysisDto>>(await _analysisRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var analysis = await _analysisRepository.GetByIdAsync(id);

            if (analysis == null) return false;

            _analysisRepository.Remove(analysis);
            await _analysisRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateAnalysisDto model)
        {
            var analysis = await _analysisRepository.GetByIdAsync(id);

            if (analysis == null) return false;

            _mapper.Map(model, analysis);

            _analysisRepository.Update(analysis);
            await _analysisRepository.SaveAsync();

            return true;
        }
    }
}
