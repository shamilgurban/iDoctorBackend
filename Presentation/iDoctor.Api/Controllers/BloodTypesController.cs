using FluentValidation.Results;
using iDoctor.Application.Dtos.BloodTypeDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.BloodTypeValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BloodTypesController : ControllerBase
    {
        private readonly IBloodTypeService _bloodTypeService;

        public BloodTypesController(IBloodTypeService bloodTypeService)
        {
            _bloodTypeService = bloodTypeService;
        }

        //[Authorize(Roles = "GetAllBloodTypes")]
        [HttpGet]
        public async Task<IActionResult> GetAllBloodTypes()
        {
            var bloodTypes = await _bloodTypeService.GetAllAsync();
            return Ok(bloodTypes);
        }

        //[Authorize(Roles = "GetBloodTypeById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBloodTypeById([FromRoute] int id)
        {
            var bloodType = await _bloodTypeService.GetByIdAsync(id);

            if (bloodType == null) return NotFound(new { Message = "Blood Type Not Found" });

            return Ok(bloodType);
        }

        //[Authorize(Roles = "CreateBloodType")]
        [HttpPost]

        public async Task<IActionResult> CreateBloodType([FromBody] CreateBloodTypeDto request)
        {
            CreateBloodTypeValidator validator = new CreateBloodTypeValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var bloodType = await _bloodTypeService.GetSingleAsync(m => m.Type == request.Type);

            if (bloodType is not null) return BadRequest(new { Message = "This Blood Type Already Exists" });

            await _bloodTypeService.AddAsync(request);

            return Ok(new { Message = "Blood Type Created Successfully" });
        }


        //[Authorize(Roles = "UpdateBloodType")]
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateBloodType(int id, [FromBody] UpdateBloodTypeDto request)
        {
            UpdateBloodTypeValidator validator = new UpdateBloodTypeValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var bloodType = await _bloodTypeService.GetSingleAsync(m => m.Type == request.Type && m.Id != request.Id);

            if (bloodType is not null) return BadRequest(new { Message = "This Blood Type Already Exists" });

            var result = await _bloodTypeService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Blood Type Not Found" });

            return Ok(new { Message = "Blood Type Updated Successfully" });
        }

        //[Authorize(Roles = "DeleteBloodType")]
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteBloodType(int id)
        {
            var result = await _bloodTypeService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Blood Type Not Found" });

            return Ok(new { Message = "Blood Type Deleted Successfully" });
        }
    }
}
