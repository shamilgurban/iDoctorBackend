using FluentValidation.Results;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.UserValidators;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            RegisterDtoValidator validator = new RegisterDtoValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _userService.GetSingleAsync(m => m.Email == request.Email);

            if (user is not null)
            {
                return BadRequest(new { Message = "This Email Already Used" });
            }

            await _userService.RegisterAsync(request);

            return Ok(new { Message = "User Created Successfully" });
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            LoginDtoValidator validator = new LoginDtoValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var token = await _userService.LoginAsync(request);

            if (token is null)
            {
                return BadRequest(new { Message = "Email or Password is wrong" });
            }

            return Ok(token);
        }
    }
}
