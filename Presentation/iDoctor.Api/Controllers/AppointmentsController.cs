using FluentValidation.Results;
using iDoctor.Application.Dtos.AppointmentDtos;
using iDoctor.Application.Dtos.EmailDtos;
using iDoctor.Application.Helpers.Enums;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.AppointmentValidators;
using iDoctor.Application.Validators.DoctorValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IEmailService _emailService;
        private readonly IPatientService _patientService; 

        public AppointmentsController(IAppointmentService appointmentService, IEmailService emailService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _emailService = emailService;
            _patientService = patientService;
        }

        //[Authorize(Roles = "GetAllAppointments")]
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAsync();
            return Ok(appointments);
        }

        //[Authorize(Roles = "GetDoctorsAllAppointmentsById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorsAllAppointmentsById([FromRoute] int id)
        {
            var appointments = await _appointmentService.GetWhereAsync(a => a.DoctorId == id);
            return Ok(appointments);
        }

        //[Authorize(Roles = "GetDoctorsPendingAppointmentsById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorsPendingAppointmentsById([FromRoute]int id)
        {
            var appointments = await _appointmentService.GetWhereAsync(a=>a.Status==(int)AppointmentStatus.Pending && a.DoctorId==id);
            return Ok(appointments);
        }

        //[Authorize(Roles = "GetAppointmentById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById([FromRoute] int id)
        {
            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment == null) return NotFound(new { Message = "Appointment Not Found" });

            return Ok(appointment);
        }

        //[Authorize(Roles = "CreateAppointment")]
        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromForm] CreateAppointmentDto request)
        {

            CreateAppointmentValidator validator = new CreateAppointmentValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var result=await _appointmentService.AddAsync(request);

            if (!result) return BadRequest(new { Message = "Something went wrong" });

            return Ok(new { Message = "Appointment Created Successfully" });
        }

        //[Authorize(Roles = "DeleteAppointment")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var result = await _appointmentService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Appointment Not Found" });

            return Ok(new { Message = "Appointment Deleted Successfully" });
        }

       // [Authorize(Roles = "AcceptAppointment")]
        [HttpPut("{id}")]

        public async Task<IActionResult> AcceptAppointment(int id,[FromBody]AcceptAppointmentDto request)
        {
            AcceptAppointmentValidator validator = new AcceptAppointmentValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment is null) return NotFound(new { Message = "Appointment not found" });

            var patient = await _patientService.GetByIdAsync(appointment.PatientId);

            if (patient is null) return NotFound(new { Message = "Patient not found" });

            var result = await _appointmentService.AcceptAppointmentAsync(id);

            if (!result) return NotFound(new { Message = "Appointment could not be accepted." });

            var emailDto = new EmailDto
            {
                ReceiversMail = patient.Email,
                Subject = "Həkim Görüşü qəbul edildi",
                Message = request.DoctorReview
            };

            await _emailService.SendEmailAsync(emailDto);

            return Ok(new { Message = "Appointment accepted successfully." });
        }

        //[Authorize(Roles = "DeclineAppointment")]
        [HttpPut("{id}")]

        public async Task<IActionResult> DeclineAppointment([FromRoute]int id)
        {

            var appointment = await _appointmentService.GetByIdAsync(id);

            if (appointment is null) return NotFound(new {Message="Appointment not found"});

            var patient = await _patientService.GetByIdAsync(appointment.PatientId);

            if (patient is null) return NotFound(new { Message = "Patient not found" });

            var result = await _appointmentService.DeclineAppointmentAsync(id);

            if (!result) return NotFound(new { Message = "Appointment could not be declined." });
   
            var emailDto = new EmailDto
            {
                ReceiversMail = patient.Email,
                Subject = "Həkim Görüşü ləğv edildi",
                Message = $@"
                             Hörmətli {patient.Name} {patient.Surname},

                            Təəssüf ki, sizin görüşünüz həkim tərəfindən ləğv edilib. Əlavə məlumat və ya 
                            yeni görüş təyin etmək üçün bizimlə əlaqə saxlaya bilərsiniz.

                            Təşəkkür edirik,
                            IDoctor Komandası"
            };

            await _emailService.SendEmailAsync(emailDto);

            return Ok(new { Message = "Appointment declined successfully." });
        }
    }
}
