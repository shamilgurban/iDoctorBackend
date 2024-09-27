using iDoctor.Application.Dtos.Token;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllAsync(bool tracking = true);
        Task<List<ResultUserDto>> GetWhereAsync(Expression<Func<User, bool>> method, bool tracking = true);
        Task<ResultUserDto> GetSingleAsync(Expression<Func<User, bool>> method, bool tracking = true);
        Task<ResultUserDto> GetByIdAsync(int id, bool tracking = true);
        Task RegisterAsync(RegisterDto model);
        Task<TokenDto> LoginAsync(LoginDto model);
        Task<bool> RemoveAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateUserDto model);
    }
}
