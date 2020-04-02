using FluentValidation;
using Typeform.Sdk.CSharp.Models.Forms;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Validations
{
    public class FormValidation : AbstractValidator<Form>
    {
        public FormValidation()
        {
            RuleFor(r => r.Title)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_RequiredProperty");
        }
    }
}