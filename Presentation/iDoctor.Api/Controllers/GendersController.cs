using FluentValidation.Results;
using iDoctor.Application.Dtos.GenderDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.GenderValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GendersController(IGenderService genderService)
        {
            _genderService = genderService;
        }

        [Authorize(Roles = "GetAllGenders")]
        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            var genders = await _genderService.GetAllAsync();
            return Ok(genders);
        }

        [Authorize(Roles = "GetGenderById")]
        [HttpGet("{id}")]
      
        public async Task<IActionResult> GetGenderById([FromRoute] int id)
        {
            var gender = await _genderService.GetByIdAsync(id);

            if (gender == null) return NotFound(new { Message = "Gender Not Found" });

            return Ok(gender);
        }

        [Authorize(Roles = "CreateGender")]
        [HttpPost]
        public async Task<IActionResult> CreateGender([FromBody] CreateGenderDto request)
        {
            CreateGenderValidator validator = new CreateGenderValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var gender = await _genderService.GetSingleAsync(m => m.Name == request.Name);

            if (gender is not null) return BadRequest(new { Message = "This Gender Already Exists" });

            await _genderService.AddAsync(request);

            return Ok(new { Message = "Gender Created Successfully" });
        }

        [Authorize(Roles = "UpdateGender")]
        [HttpPut("{id}")]      
        public async Task<IActionResult> UpdateGender(int id, [FromBody] UpdateGenderDto request)
        {
            UpdateGenderValidator validator = new UpdateGenderValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
           
            var gender = await _genderService.GetSingleAsync(m => m.Name == request.Name && m.Id != request.Id);

            if (gender is not null) return BadRequest(new { Message = "This Gender Already Exists" });
           
            var result = await _genderService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Gender Not Found" });

            return Ok(new { Message = "Gender Updated Successfully" });
        }

        [Authorize(Roles = "DeleteGender")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGender(int id)
        {
            var result = await _genderService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Gender Not Found" });

            return Ok(new { Message = "Gender Deleted Successfully" });
        }
    }
}
