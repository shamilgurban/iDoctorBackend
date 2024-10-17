using FluentValidation.Results;
using iDoctor.Application.Dtos.RoleDtos;
using iDoctor.Application.Services.Interfaces;
using iDoctor.Application.Validators.RoleValidators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iDoctor.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

       // [Authorize(Roles = "GetAllRoles")]
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

       // [Authorize(Roles = "GetRoleById")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById([FromRoute] int id)
        {
            var role = await _roleService.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound(new { Message = "Role Not Found" });
            }

            return Ok(role);
        }

        //[Authorize(Roles = "CreateRole")]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleDto request)
        {
            CreateRoleValidator validator=new CreateRoleValidator();
            ValidationResult validationResult=validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var role = await _roleService.GetSingleAsync(m=>m.Name==request.Name);

            if(role is not null)
            {
                return BadRequest(new {Message="This Role Already Exists" });
            }

            await _roleService.AddAsync(request);

            return Ok(new {Message="Role Created Successfully"});
        }

        //[Authorize(Roles = "UpdateRole")]
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleDto request)
        {
            UpdateRoleValidator validator = new UpdateRoleValidator();
            ValidationResult validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var role = await _roleService.GetSingleAsync(m => m.Name == request.Name && m.Id!=request.Id);

            if (role is not null)
            {
                return BadRequest(new { Message = "This Role Already Exists" });
            }
            var result = await _roleService.UpdateAsync(id, request);

            if (!result)
            {
                return NotFound(new { Message = "Role Not Found" });
            }

            return Ok(new { Message = "Role Updated Successfully" });
        }

        //[Authorize(Roles = "DeleteRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result=await _roleService.RemoveAsync(id);

            if (!result)
            {
                return NotFound(new { Message = "Role Not Found" });
            }

            return Ok(new { Message = "Role Deleted Successfully" });
        }
    }
}
