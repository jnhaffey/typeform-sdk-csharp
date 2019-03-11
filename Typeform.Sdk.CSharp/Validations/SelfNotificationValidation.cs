using System.Linq;
using FluentValidation;
using Typeform.Sdk.CSharp.Models.Forms;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Validations
{
    public class SelfNotificationValidation : AbstractValidator<SelfNotification>
    {
        public SelfNotificationValidation()
        {
            RuleFor(r => r.Recipients)
                .Must(l => l.Any())
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiresOne");

            RuleFor(r => r.Subject)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");

            RuleFor(r => r.Message)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
        }
    }
}