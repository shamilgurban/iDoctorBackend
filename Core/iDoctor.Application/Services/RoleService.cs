using AutoMapper;
using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;


namespace iDoctor.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleService(IRoleRepository roleRepository,IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CreateRoleDto model)
        {
           await _roleRepository.AddAsync(_mapper.Map<Role>(model));
        }

        public async Task<List<ResultRoleDto>> GetAllAsync(bool tracking = true)
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<List<ResultRoleDto>>(roles);
        }

        public async Task<ResultRoleDto> GetByIdAsync(int id, bool tracking = true)
        {   
            var role = await _roleRepository.GetByIdAsync(id);

            if(role is null)
            {
                return null;
            }
            return _mapper.Map<ResultRoleDto>(role);
        }

        public async Task<ResultRoleDto> GetSingleAsync(Expression<Func<Role, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultRoleDto>(await _roleRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultRoleDto>> GetWhereAsync(Expression<Func<Role, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultRoleDto>>(_roleRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role==null)
            {
                return false;
            }

            await _roleRepository.RemoveAsync(role);

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateRoleDto model)
        {
            var role = await _roleRepository.GetByIdAsync(id);

            if (role == null) 
            {
                return false;
            }
            _mapper.Map(model, role);
            await _roleRepository.UpdateAsync(role);

            return true;
        }
    }
}
