using FluentValidation;
using PestKitOnionAB104.Application.DTOs.Author;

namespace PestKitOnionAB104.Application.Validators
{
    public class AuthorCreateDtoValidator : AbstractValidator<AuthorCreateDto>
    {
        public AuthorCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is important")
                .MaximumLength(50).WithMessage("Max uzunlugu 50")
                .MinimumLength(5).WithMessage("Min uzunlugu 5");
        }
    }
}
