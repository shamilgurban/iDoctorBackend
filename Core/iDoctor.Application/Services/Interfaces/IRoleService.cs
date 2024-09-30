using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Domain.Entities;
using System.Linq.Expressions;


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
