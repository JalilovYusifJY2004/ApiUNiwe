using FluentValidation;
using PestKitOnionAB104.Application.DTOs.Tag;

namespace PestKitOnionAB104.Application.Validators
{
    internal class TagCreateDtoValidator : AbstractValidator<TagCreateDto>
    {
        public TagCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).MinimumLength(5);
        }
    }
}
