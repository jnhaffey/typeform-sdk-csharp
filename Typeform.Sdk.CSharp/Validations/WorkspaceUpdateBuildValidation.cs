using FluentValidation;
using Typeform.Sdk.CSharp.Builders;

namespace Typeform.Sdk.CSharp.Validations
{
    public class WorkspaceUpdateBuildValidation : AbstractValidator<WorkspaceUpdateBuilder>
    {
        public WorkspaceUpdateBuildValidation()
        {
            RuleFor(b => b.WorkspaceId).NotEmpty().WithLocalizedMessage(typeof(Resources.ErrorMessages),
                "Validation_WorkspaceUpdateBuilder_MissingWorkspaceId");
        }
    }
}