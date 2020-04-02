using System.Linq;
using FluentValidation;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Models.Workspaces.Validations
{
    public class UpdateWorkspaceValidation : AbstractValidator<UpdateWorkspace>
    {
        public UpdateWorkspaceValidation()
        {
            RuleFor(w => w.Id)
                .NotEmpty()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_MissingWorkspaceId");

            RuleFor(w => w.GetMemberUpdates)
                .NotEmpty()
                .When(w => w.GetNameChange == null)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_NoChange");

            RuleFor(w => w.GetNameChange)
                .NotEmpty()
                .When(w => w.GetMemberUpdates.Any() == false)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceModifier_NoChange");
        }
    }
}