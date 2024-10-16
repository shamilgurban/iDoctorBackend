using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;

namespace iDoctor.Persistence.Repositories
{
    public class AnalysisRepository : GenericRepository<Analysis>, IAnalysisRepository
    {
        public AnalysisRepository(AppDbContext context) : base(context)
        {
        }
    }
}
