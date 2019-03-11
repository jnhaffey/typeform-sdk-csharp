using FluentValidation;
using Typeform.Sdk.CSharp.Models.Forms;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Validations
{
    public class RespondentNotificationValidation : AbstractValidator<RespondentNotification>
    {
        public RespondentNotificationValidation()
        {
            RuleFor(r => r.Recipient)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");

            RuleFor(r => r.Subject)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");

            RuleFor(r => r.Message)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
        }
    }
}