using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IRoleService 
    {
        Task<List<ResultRoleDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultRoleDto>> GetWhereAsync(Expression<Func<Role, bool>> method, bool tracking = true);
        Task<ResultRoleDto> GetSingleAsync(Expression<Func<Role, bool>> method, bool tracking = true);
        Task<ResultRoleDto> GetByIdAsync(int id, bool tracking = true);
        Task AddAsync(CreateRoleDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id,UpdateRoleDto model);
    }
}
