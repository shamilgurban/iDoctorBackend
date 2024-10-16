using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;


namespace iDoctor.Persistence.Repositories
{
    public class GenderRepository : GenericRepository<Gender>, IGenderRepository
    {
        public GenderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
