using System.Linq;
using FluentValidation;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Models.Workspaces.Validations
{
    public class UpdateWorkspaceValidation : AbstractValidator<UpdateWorkspace>
    {
        public UpdateWorkspaceValidation()
        {
            RuleFor(w => w.WorkspaceId)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_MissingWorkspaceId");

            RuleFor(w => w.UpdateMemberOptions)
                .NotEmpty()
                .When(w => w.UpdateWorkspaceName == null)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_NoChange");

            RuleFor(w => w.UpdateWorkspaceName)
                .NotEmpty()
                .When(w => w.UpdateMemberOptions.Any() == false)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_NoChange");
        }
    }
}