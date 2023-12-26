using FluentValidation;
using PestKitOnionAB104.Application.DTOs.Position;

namespace PestKitOnionAB104.Application.Validators
{
    internal class PositionCreateDtoValidator : AbstractValidator<PositionCreateDto>
    {
        public PositionCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
