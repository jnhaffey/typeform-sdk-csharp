using FluentValidation;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Models.Workspaces.Validations
{
    public class CreateWorkspaceValidation : AbstractValidator<CreateWorkspace>
    {
        public CreateWorkspaceValidation()
        {
            RuleFor(w => w.Name)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_CreateWorkspace_MissingWorkspaceName");
        }
    }
}