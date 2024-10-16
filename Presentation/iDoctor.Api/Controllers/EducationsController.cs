using iDoctor.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EducationsController : ControllerBase
    {
        private readonly IEducationService _educationService;

        public EducationsController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [Authorize(Roles = "GetAllEducations")]
        [HttpGet]

        public async Task<IActionResult> GetAllEducations()
        {
            var educations = await _educationService.GetAllAsync();
            return Ok(educations);
        }

        [Authorize(Roles = "GetEducationById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationById([FromRoute] int id)
        {
            var education = await _educationService.GetByIdAsync(id);

            if (education == null) return NotFound(new { Message = "Education Not Found" });

            return Ok(education);
        }

        [Authorize(Roles = "GetEducationsByDoctorId")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEducationsByDoctorId([FromRoute]int id)
        {
            var educations=await _educationService.GetWhereAsync(e=>e.DoctorId==id);

            if (educations == null) return NotFound(new { Message = "Doctor don't have educations" });

            return Ok(educations);
        }
    }
}
