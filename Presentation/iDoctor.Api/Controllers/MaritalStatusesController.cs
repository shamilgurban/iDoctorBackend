using FluentValidation.Results;
using iDoctor.Application.Dtos.MaritalStatusDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.MaritalStatusValidatos;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MaritalStatusesController : ControllerBase
    {
        private readonly IMaritalStatusService _maritalStatusService;

        public MaritalStatusesController(IMaritalStatusService maritalStatusService)
        {
            _maritalStatusService = maritalStatusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaritalStatuss()
        {
            var maritalStatuses = await _maritalStatusService.GetAllAsync();
            return Ok(maritalStatuses);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetMaritalStatusById([FromRoute] int id)
        {
            var maritalStatus = await _maritalStatusService.GetByIdAsync(id);

            if (maritalStatus == null) return NotFound(new { Message = "Marital Status Not Found" });

            return Ok(maritalStatus);
        }

        [HttpPost]

        public async Task<IActionResult> CreateMaritalStatus([FromBody] CreateMaritalStatusDto request)
        {
            CreateMaritalStatusValidator validator = new CreateMaritalStatusValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var maritalStatus = await _maritalStatusService.GetSingleAsync(m => m.Status == request.Status);

            if (maritalStatus is not null) return BadRequest(new { Message = "This Marital Status Already Exists" });

            await _maritalStatusService.AddAsync(request);

            return Ok(new { Message = "Marital Status Created Successfully" });
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateMaritalStatus(int id, [FromBody] UpdateMaritalStatusDto request)
        {
            UpdateMaritalStatusValidator validator = new UpdateMaritalStatusValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var maritalStatus = await _maritalStatusService.GetSingleAsync(m => m.Status == request.Status && m.Id != request.Id);

            if (maritalStatus is not null) return BadRequest(new { Message = "This Marital Status Already Exists" });

            var result = await _maritalStatusService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Marital Status Not Found" });

            return Ok(new { Message = "Marital Status Updated Successfully" });
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteMaritalStatus(int id)
        {
            var result = await _maritalStatusService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Marital Status Not Found" });

            return Ok(new { Message = "Marital Status Deleted Successfully" });
        }
    }
}
