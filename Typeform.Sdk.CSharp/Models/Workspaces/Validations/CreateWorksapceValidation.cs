using FluentValidation;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Models.Workspaces.Validations
{
    public class CreateWorksapceValidation : AbstractValidator<CreateWorkspace>
    {
        public CreateWorksapceValidation()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceBuilder_MissingWorkspaceName");
        }
    }
}