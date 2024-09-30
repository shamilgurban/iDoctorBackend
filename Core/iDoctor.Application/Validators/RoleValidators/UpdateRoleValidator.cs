using FluentValidation;
using iDoctor.Application.Dtos.RoleDtos;


namespace iDoctor.Application.Validators.RoleValidators
{
    public class UpdateRoleValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Role name is required.")
             .Length(2, 50).WithMessage("Role name must be between 2 and 50 characters.");
        }
    }
}
