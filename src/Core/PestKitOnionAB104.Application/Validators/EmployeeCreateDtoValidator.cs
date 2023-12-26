using FluentValidation;
using PestKitOnionAB104.Application.DTOs.Employee;

namespace PestKitOnionAB104.Application.Validators
{
    internal class EmployeeCreateDtoValidator:AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
