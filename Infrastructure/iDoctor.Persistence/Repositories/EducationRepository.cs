using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;

namespace iDoctor.Persistence.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
