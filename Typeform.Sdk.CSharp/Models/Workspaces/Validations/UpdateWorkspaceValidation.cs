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
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceUpdate_MissingWorkspaceId");
            RuleFor(w => w.UpdateMemberOptions)
                .NotNull()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspaceUpdate_UpdateOperationEmpty");
            RuleForEach(w => w.UpdateMemberOptions)
                .SetValidator(new WorkspacePatchValidation());
        }
    }
}