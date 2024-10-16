using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;


namespace iDoctor.Persistence.Repositories
{
    public class BloodTypeRepository : GenericRepository<BloodType>, IBloodTypeRepository
    {
        public BloodTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
