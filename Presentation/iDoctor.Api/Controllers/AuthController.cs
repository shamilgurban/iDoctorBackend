using FluentValidation.Results;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Dtos.EmailDtos;
using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Application.Dtos.UserDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.DoctorValidators;
using iDoctor.Application.Validators.PatientValidators;
using iDoctor.Application.Validators.UserValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IEmailService _emailService;

        public AuthController(IUserService userService, 
                              IPatientService patientService, 
                              IDoctorService doctorService,
                              IEmailService emailService)
        {
            _userService = userService;
            _patientService = patientService;
            _doctorService = doctorService;
            _emailService = emailService;
        }

        //[Authorize(Roles = "GetAllUsers")]
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

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
 
            var user = await _userService.GetSingleAsync(m => m.Email == request.Email);

            if (user is not null) return BadRequest(new { Message = "This Email Already Used" });
        
            await _userService.RegisterAsync(request);

            return Ok(new { Message = "User Created Successfully" });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDto request)
        {
            RegisterPatientDtoValidator validator = new RegisterPatientDtoValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
          
            var user = await _userService.GetSingleAsync(m => m.Email == request.Email);

            if (user is not null) return BadRequest(new { Message = "This Email Already Used" });
          
            await _patientService.RegisterAsync(request);

            return Ok(new { Message = "Patient Created Successfully" });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterDoctor([FromForm] RegisterDoctorDto request)
        {
            RegisterDoctorValidator validator = new RegisterDoctorValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
           
            var user = await _userService.GetSingleAsync(m => m.Email == request.Email);

            if (user is not null) return BadRequest(new { Message = "This Email Already Used" });

            var result = await _doctorService.RegisterAsync(request);

            if(!result) return BadRequest(new { Message = "Something went wrong" });

            var mail = new EmailDto();
            mail.ReceiversMail = request.Email;
            mail.Subject = "Həkim Qeydiyyatının Təsdiqi";
            mail.Message = $@"Hörmətli {request.Name} {request.Surname},

                              iDoctor platformasında qeydiyyatdan keçdiyiniz üçün təşəkkür edirik.
                              Sənədlərinizin yoxlanışı həyata keçiriləcək və hesabınız təsdiqləndikdən 
                              sonra sizə məlumat veriləcək.

                              iDoctor Komandası adından sizi salamlayırıq və xoş gəldiniz deyirik!

                              Hörmətlə,
                              iDoctor Komandası";

            await _emailService.SendEmailAsync(mail);

            return Ok(new { Message = "Doctor Created Successfully" });
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            LoginDtoValidator validator = new LoginDtoValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var token = await _userService.LoginAsync(request);

            if (token is null) return BadRequest(new { Message = "Email or Password is wrong" });
           
            return Ok(token);
        }
    }
}
