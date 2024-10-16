using iDoctor.Application.Dtos.AnalysisDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IAnalysisService
    {
        Task<List<ResultAnalysisDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultAnalysisDto>> GetWhereAsync(Expression<Func<Analysis, bool>> method, bool tracking = true);
        Task<ResultAnalysisDto> GetSingleAsync(Expression<Func<Analysis, bool>> method, bool tracking = true);
        Task<ResultAnalysisDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateAnalysisDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateAnalysisDto model);
    }
}
