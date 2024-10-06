using AutoMapper;
using iDoctor.Application.Dtos.Token;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System.Linq.Expressions;

namespace iDoctor.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper,
                           IPasswordService passwordService,
                           ITokenService tokenService,
                           IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _tokenService = tokenService;
            _roleRepository = roleRepository;
        }

        public async Task RegisterAsync(RegisterDto model)
        {
            var user = _mapper.Map<User>(model);
            user.HashedPassword = _passwordService.HashPassword(model.Password);
            user.Type = (int)UserTypes.Admin;

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();
        }

        public async Task<List<ResultUserDto>> GetAllAsync(bool tracking = true)
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<ResultUserDto>>(users);
        }

        public async Task<ResultUserDto> GetByIdAsync(int id, bool tracking = true)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user is null) return null;
          
            return _mapper.Map<ResultUserDto>(user);
        }

        public async Task<ResultUserDto> GetSingleAsync(Expression<Func<User, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultUserDto>(await _userRepository.GetSingleAsync(method,tracking,u=>u.Patient,u=>u.Doctor));
        }

        public async Task<List<ResultUserDto>> GetWhereAsync(Expression<Func<User, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultUserDto>>(await _userRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return false;
            
            await _userRepository.RemoveAsync(user);
            await _userRepository.SaveAsync();

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto model)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null) return false;
       
            _mapper.Map(model, user);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveAsync();

            return true;
        }

        public async Task<TokenDto> LoginAsync(LoginDto model)
        {
            var tracking = true; 

            var user = await _userRepository.GetSingleAsync(m => m.Email == model.Email,tracking,u=>u.Doctor);

            if(user is null) return null;

            if (user.Type == (int)UserTypes.Doctor && !user.Doctor.IsVerified) return null;
            
            string hashedPassword = user.HashedPassword;

            bool isValid = _passwordService.VerifyPassword(model.Password, hashedPassword);

            if (!isValid) return null;
          
            int userType = user.Type;

            var roles = await _roleRepository.GetWhereAsync(m => m.UserType == userType);


            if (roles is null) return null;
           
            var roleNames=roles.Select(r => r.Name).ToList();

            string type=string.Empty;

            foreach (var item in Enum.GetValues(typeof(UserTypes)))
            {
                if ((int)item == userType)
                {
                    type=item.ToString();
                }
            }

            return _tokenService.GenerateJwtToken(new TokenCreateDto
            {
               Id=user.Id,
               Email=user.Email,
               Roles=roleNames,
               UserType=type
            });
        }
    }
}
