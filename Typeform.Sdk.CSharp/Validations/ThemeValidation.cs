using FluentValidation;
using Typeform.Sdk.CSharp.Models.Themes;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Validations
{
    public class ThemeValidation : AbstractValidator<Theme>
    {
        public ThemeValidation()
        {
            RuleFor(t => t.Colors)
                .NotNull()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Colors.Background)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Colors.Answer)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Colors.Question)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Colors.Button)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Font)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
            RuleFor(t => t.Name)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
        }
    }
}