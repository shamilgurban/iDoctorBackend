using FluentValidation.Results;
using iDoctor.Application.Dtos.PatientDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.PatientValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService,IUserService userService)
        {
            _patientService = patientService;
            _userService = userService;
        }

        //[Authorize(Roles = "GetAllPatients")]
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllAsync();
            return Ok(patients);
        }

        //[Authorize(Roles = "GetPatientById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById([FromRoute] int id)
        {
            var patient = await _patientService.GetByIdAsync(id);

            if (patient == null) return NotFound(new { Message = "Patient Not Found" });
           
            return Ok(patient);
        }

        //[Authorize(Roles = "UpdatePatient")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromForm] UpdatePatientDto request)
        {
            UpdatePatientDtoValidator validator = new UpdatePatientDtoValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
          
            var userWithEmail = await _userService.GetSingleAsync(m => m.Email == request.Email && ((m.Doctor != null) || (m.Patient.Id != id)));

            if (userWithEmail is not null) return BadRequest(new { Message = "This Email Already Taken" });
         
            var userWithPhone = await _userService.GetSingleAsync(m => m.Phone == request.Phone && ((m.Doctor != null) || (m.Patient.Id != id)));

            if (userWithPhone is not null) return BadRequest(new { Message = "This Phone Number Already Taken" });
          

            var result = await _patientService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Patient Not Found" });
           

            return Ok(new { Message = "Patient Updated Successfully" });
        }

        //[Authorize(Roles = "DeletePatient")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Patient Not Found" });
           
            return Ok(new { Message = "Patient Deleted Successfully" });
        }
    }
}
