using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;


namespace iDoctor.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
