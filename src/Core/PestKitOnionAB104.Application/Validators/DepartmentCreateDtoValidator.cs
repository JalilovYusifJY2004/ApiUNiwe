using FluentValidation;
using PestKitOnionAB104.Application.DTOs.Department;

namespace PestKitOnionAB104.Application.Validators
{
    internal class DepartmentCreateDtoValidator : AbstractValidator<DepartmentCreateDto>
    {
        public DepartmentCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
