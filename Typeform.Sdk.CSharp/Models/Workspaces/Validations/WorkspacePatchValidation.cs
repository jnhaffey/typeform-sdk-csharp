using FluentValidation;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Models.Workspaces.Validations
{
    public class WorkspacePatchValidation : AbstractValidator<PatchDocument<WorkspacePatchValueEmail>>
    {
        public WorkspacePatchValidation()
        {
            RuleFor(w => w.Operation)
                .IsInEnum()
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspacePatchUpdate_InvalidEnumValue");

            RuleFor(x => x)
                .Must(x => x.Operation.Equals(OperationType.Replace))
                .Must(x => x.Path.Equals(Constants.PatchOptions.Workspace.Name))
                .Must(x => x.Value != null)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspacePatchUpdate_InvalidNameChange");

            RuleFor(x => x)
                .Must(x => x.Operation.Equals(OperationType.Add))
                .Must(x => x.Path.Equals(Constants.PatchOptions.Workspace.Member))
                .Must(x => x.Value.Email != null)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspacePatchUpdate_InvalidAddMember");

            RuleFor(x => x)
                .Must(x => x.Operation.Equals(OperationType.Remove))
                .Must(x => x.Path.Equals(Constants.PatchOptions.Workspace.Member))
                .Must(x => x.Value.Email != null)
                .WithLocalizedMessage(typeof(ErrorMessages), "Validation_WorkspacePatchUpdate_InvalidRemoveMember");
        }
    }
}