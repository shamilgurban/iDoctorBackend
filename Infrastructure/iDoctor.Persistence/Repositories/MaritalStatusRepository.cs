﻿using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using iDoctor.Persistence.Context;


namespace iDoctor.Persistence.Repositories
{
    public class MaritalStatusRepository : GenericRepository<MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(AppDbContext context) : base(context)
        {
        }
    }
}
