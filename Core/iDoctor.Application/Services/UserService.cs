using AutoMapper;
using iDoctor.Application.Dtos.Token;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Domain.Entities;
using iDoctor.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace iDoctor.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,
                           IMapper mapper,
                           IPasswordService passwordService,
                           ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task RegisterAsync(RegisterDto model)
        {
            model.Password = _passwordService.HashPassword(model.Password);

            await _userRepository.AddAsync(_mapper.Map<User>(model));
        }

        public async Task<List<ResultUserDto>> GetAllAsync(bool tracking = true)
        {
            var Users = await _userRepository.GetAllAsync();
            return _mapper.Map<List<ResultUserDto>>(Users);
        }

        public async Task<ResultUserDto> GetByIdAsync(int id, bool tracking = true)
        {
            var User = await _userRepository.GetByIdAsync(id);

            if (User is null)
            {
                return null;
            }
            return _mapper.Map<ResultUserDto>(User);
        }

        public async Task<ResultUserDto> GetSingleAsync(Expression<Func<User, bool>> method, bool tracking = true)
        {
            return _mapper.Map<ResultUserDto>(await _userRepository.GetSingleAsync(method));
        }

        public async Task<List<ResultUserDto>> GetWhereAsync(Expression<Func<User, bool>> method, bool tracking = true)
        {
            return _mapper.Map<List<ResultUserDto>>(_userRepository.GetWhereAsync(method));
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var User = await _userRepository.GetByIdAsync(id);

            if (User == null)
            {
                return false;
            }

            await _userRepository.RemoveAsync(User);

            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateUserDto model)
        {
            var User = await _userRepository.GetByIdAsync(id);

            if (User == null)
            {
                return false;
            }
            _mapper.Map(model, User);
            await _userRepository.UpdateAsync(User);

            return true;
        }

        public async Task<TokenDto> LoginAsync(LoginDto model)
        {
            var user = await _userRepository.GetSingleAsync(m => m.Email == model.Email);

            if(user is null)
            {
                return null;
            }

            string hashedPassword = user.HashedPassword;

            bool isValid = _passwordService.VerifyPassword(model.Password, hashedPassword);

            if (!isValid)
            {
                return null;
            }

            
            return _tokenService.GenerateJwtToken(new TokenCreateDto
            {
               Id=user.Id,
               Email=user.Email,
            });
        }
    }
}
