using FluentValidation.Results;
using iDoctor.Application.Dtos.AnalysisDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.AnalysisValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AnalysesController : ControllerBase
    {
        private readonly IAnalysisService _analysisService;

        public AnalysesController(IAnalysisService analysisService)
        {
            _analysisService = analysisService;
        }

        //[Authorize(Roles = "GetAllAnalyses")]
        [HttpGet]
        public async Task<IActionResult> GetAllAnalyses()
        {
            var analyses = await _analysisService.GetAllAsync();
            return Ok(analyses);
        }

        //[Authorize(Roles = "GetAnalysisById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnalysisById([FromRoute] int id)
        {
            var analysis = await _analysisService.GetByIdAsync(id);

            if (analysis == null) return NotFound(new { Message = "Analysis Not Found" });

            return Ok(analysis);
        }


        //[Authorize(Roles = "CreateAnalysis")]
        [HttpPost]
        public async Task<IActionResult> CreateAnalysis([FromBody] CreateAnalysisDto request)
        {
            CreateAnalysisValidator validator = new CreateAnalysisValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var analysis = await _analysisService.GetSingleAsync(m => m.Name == request.Name);

            if (analysis is not null) return BadRequest(new { Message = "This Analysis Already Exists" });

            await _analysisService.AddAsync(request);

            return Ok(new { Message = "Analysis Created Successfully" });
        }

        //[Authorize(Roles = "UpdateAnalysis")]
        [HttpPut("{id}")]     
        public async Task<IActionResult> UpdateAnalysis(int id, [FromBody] UpdateAnalysisDto request)
        {
            UpdateAnalysisValidator validator = new UpdateAnalysisValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var analysis = await _analysisService.GetSingleAsync(m => m.Name == request.Name && m.Id != request.Id);

            if (analysis is not null) return BadRequest(new { Message = "This Analysis Already Exists" });

            var result = await _analysisService.UpdateAsync(id, request);

            if (!result) return NotFound(new { Message = "Analysis Not Found" });

            return Ok(new { Message = "Analysis Updated Successfully" });
        }

        //[Authorize(Roles = "DeleteAnalysis")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysis(int id)
        {
            var result = await _analysisService.RemoveAsync(id);

            if (!result) return NotFound(new { Message = "Analysis Not Found" });

            return Ok(new { Message = "Analysis Deleted Successfully" });
        }
    }
}
