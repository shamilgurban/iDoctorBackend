using FluentValidation.Results;
using iDoctor.Application.Dtos.SpecialtyDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.SpecialtyValidators;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SpecialtiesController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtiesController(ISpecialtyService specialtyService)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSpecialties()
        {
            var specialties = await _specialtyService.GetAllAsync();
            return Ok(specialties);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetSpecialtyById([FromRoute] int id)
        {
            var specialty = await _specialtyService.GetByIdAsync(id);

            if (specialty == null) return NotFound(new { Message = "Specialty Not Found" });

            return Ok(specialty);
        }

        [HttpPost]

        public async Task<IActionResult> CreateSpecialty([FromBody] CreateSpecialtyDto request)
        {
            CreateSpecialtyValidator validator = new CreateSpecialtyValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var specialty = await _specialtyService.GetSingleAsync(m => m.Name == request.Name);

            if (specialty is not null) return BadRequest(new { Message = "This Specialty Already Exists" });

            await _specialtyService.AddAsync(request);

            return Ok(new { Message = "Specialty Created Successfully" });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateSpecialty(int id, [FromBody] UpdateSpecialtyDto request)
        {
            UpdateSpecialtyValidator validator = new UpdateSpecialtyValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var specialty = await _specialtyService.GetSingleAsync(m => m.Name == request.Name && m.Id != request.Id);

            if (specialty is not null) return BadRequest(new { Message = "This Specialty Already Exists" });

            var result = await _specialtyService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Specialty Not Found" });

            return Ok(new { Message = "Specialty Updated Successfully" });
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            var result = await _specialtyService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Specialty Not Found" });

            return Ok(new { Message = "Specialty Deleted Successfully" });
        }
    }
}
