using FluentValidation.Results;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.DoctorValidators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDoctorService _doctorService;
        private readonly IEmailService _emailService;

        public DoctorsController(IDoctorService doctorService, IUserService userService, IEmailService emailService)
        {
            _userService = userService;
            _doctorService = doctorService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();

            return Ok(doctors);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound(new { Message = "Doctor Not Found" });
            }

            return Ok(doctor);
        }


        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateDoctor(int id, [FromForm] UpdateDoctorDto request)
        {
            UpdateDoctorValidator validator = new UpdateDoctorValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = await _userService.GetSingleAsync(m => m.Email == request.Email && ((m.Patient != null) || (m.Doctor.Id != id)));
            
            if (user is not null)
            {
                return BadRequest(new { Message = "This Email Already Taken" });
            }
            var result = await _doctorService.UpdateAsync(id, request);

            if (!result)
            {
                return NotFound(new { Message = "Doctor Not Found" });
            }

            return Ok(new { Message = "Doctor Updated Successfully" });
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteDoctor(int id)
        {
            var result = await _doctorService.RemoveAsync(id);

            if (!result)
            {
                return NotFound(new { Message = "Doctor Not Found" });
            }

            return Ok(new { Message = "Doctor Deleted Successfully" });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult>VerifyDoctor([FromRoute]int id)
        {
            var result=await _doctorService.VerifyDoctorAsync(id);

            if(!result) return NotFound(new { Message = "Doctor not found or could not be verified." });

            var doctor=await _doctorService.GetByIdAsync(id);

            var emailDto = new EmailDto
            {
                ReceiversMail = doctor.Email,
                Subject = "Your Doctor Account Has Been Verified",
                Message = $@"
                             Dear Dr. {doctor.Name} {doctor.Surname},
                             We are pleased to inform you that your doctor account on the iDoctor platform has been successfully verified.
                             You now have full access to the platform, where you can manage patient appointments, view test results, and provide consultations.
                             If you have any questions or need further assistance, feel free to contact our support team at support@idoctor.com.
                             Thank you for choosing iDoctor!

                             Best regards,
                             iDoctor Team"
            };


            await _emailService.SendEmailAsync(emailDto);

            return Ok(new { Message = "Doctor verified successfully." });
        }

        [HttpGet]
        public async Task<IActionResult> GetVerifiedDoctors()
        {
            var doctors = await _doctorService.GetWhereAsync(d=>d.IsVerified);
            return Ok(doctors);
        }

        [HttpGet]
        public async Task<IActionResult> GetUnVerifiedDoctors()
        {
            var doctors = await _doctorService.GetWhereAsync(d => d.IsVerified==false);
            return Ok(doctors);
        }
    }
}
