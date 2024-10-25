using FluentValidation.Results;
using iDoctor.Application.Dtos.DoctorDtos;
using iDoctor.Application.Dtos.EmailDtos;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.DoctorValidators;
using Microsoft.AspNetCore.Authorization;
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

        //[Authorize(Roles = "GetAllDoctors")]
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var doctors = await _doctorService.GetAllAsync();

            return Ok(doctors);
        }

        //[Authorize(Roles = "GetDoctorById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById([FromRoute] int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound(new { Message = "Doctor Not Found" });
            }

            return Ok(doctor);
        }

        //[Authorize(Roles = "UpdateDoctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromForm] UpdateDoctorDto request)
        {
            UpdateDoctorValidator validator = new UpdateDoctorValidator();
            ValidationResult validationResult = validator.Validate(request);        

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var user = await _userService.GetSingleAsync(m => m.Email == request.Email && ((m.Patient != null) || (m.Doctor.Id != id)));
            
            if (user is not null) return BadRequest(new { Message = "This Email Already Taken" });
         
            var result = await _doctorService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Doctor Not Found" });
          
            return Ok(new { Message = "Doctor Updated Successfully" });
        }

        //[Authorize(Roles = "DeleteDoctor")]
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

        //[Authorize(Roles = "VerifyDoctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult>VerifyDoctor([FromRoute]int id)
        {
            var result=await _doctorService.VerifyDoctorAsync(id);

            if(!result) return NotFound(new { Message = "Doctor not found or could not be verified." });

            var doctor=await _doctorService.GetByIdAsync(id);

            var emailDto = new EmailDto
            {
                ReceiversMail = doctor.Email,
                Subject = "Həkim Hesabınız Təsdiqləndi",
                Message = $@"
                             Hörmətli Dr. {doctor.Name} {doctor.Surname},
                             Sizi iDoctor platformasında həkim hesabınızın uğurla təsdiqləndiyi barədə məlumatlandırmaqdan məmnunluq duyuruq.
                             Artıq platformaya tam giriş imkanı əldə etmisiniz və burada pasiyent görüşlərini idarə edə, test nəticələrinə baxa və məsləhətlər verə bilərsiniz.
                             Hər hansı bir sualınız yaranarsa və ya əlavə köməyə ehtiyacınız olarsa, support@idoctor.com ünvanı vasitəsilə dəstək komandamızla əlaqə saxlaya bilərsiniz.

                             iDoctor-u seçdiyiniz üçün təşəkkür edirik!

                             Hörmətlə,
                             iDoctor Komandası"
            };


            await _emailService.SendEmailAsync(emailDto);

            return Ok(new { Message = "Doctor verified successfully." });
        }

        //[Authorize(Roles = "RejectDoctor")]
        [HttpPut("{id}")]
        public async Task<IActionResult> RejectDoctor([FromRoute] int id)
        {
            var result = await _doctorService.RejectDoctorAsync(id);

            if (!result) return NotFound(new { Message = "Doctor not found or could not be rejected." });

            var doctor = await _doctorService.GetByIdAsync(id);

            var emailDto = new EmailDto
            {
                ReceiversMail = doctor.Email,
                Subject = "Həkim Qeydiyyatınız Təsdiqlənmədi",
                Message = $@"
                             Hörmətli {doctor.Name} {doctor.Surname},
                             Təəssüf hissi ilə bildirmək istəyirik ki, iDoctor platformasında həkim qeydiyyatınız üçün təqdim etdiyiniz məlumat və sənədlər təhlil edilərkən, təsdiqlənməyə uyğun olmadığı müəyyən edilmişdir.
                 
                             Əgər əlavə məlumat və ya suallarınız varsa və ya hesabınızın təsdiqlənməməsi səbəbləri ilə bağlı daha ətraflı məlumat almaq istəyirsinizsə, xahiş edirik support@idoctor.com ünvanı vasitəsilə bizimlə əlaqə saxlayın.

                             iDoctor platformasına göstərdiyiniz maraq üçün təşəkkür edirik və gələcəkdə yenidən müraciət etməyinizi arzu edirik.

                             Hörmətlə,
                             iDoctor Komandası"
            };


            await _emailService.SendEmailAsync(emailDto);

            return Ok(new { Message = "Doctor rejected successfully." });
        }

        // [Authorize(Roles = "GetVerifiedDoctors")]
        [HttpGet]
        public async Task<IActionResult> GetVerifiedDoctors()
        {
            var doctors = await _doctorService.GetWhereAsync(d => d.VerificationStatus == (int)VerificationStatuses.Verified);
            return Ok(doctors);
        }

        // [Authorize(Roles = "GetUnverifiedDoctors")]
        [HttpGet]
        public async Task<IActionResult> GetUnverifiedDoctors()
        {
            var doctors = await _doctorService.GetWhereAsync(d => d.VerificationStatus == (int)VerificationStatuses.Unverified);
            return Ok(doctors);
        }

        // [Authorize(Roles = "GetRejectedDoctors")]
        [HttpGet]
        public async Task<IActionResult> GetRejectedDoctors()
        {
            var doctors = await _doctorService.GetWhereAsync(d => d.VerificationStatus == (int)VerificationStatuses.Rejected);
            return Ok(doctors);
        }
    }
}
