using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models.Shared;
using Typeform.Sdk.CSharp.Models.Workspaces.Validations;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class UpdateWorkspace : ViewWorkspace
    {
        internal readonly List<PatchDocument<WorkspacePatchValueEmail>> UpdatedMemberList;
        private readonly UpdateWorkspaceValidation _validator;
        internal PatchDocument<string> UpdatedWorkspaceName;

        private UpdateWorkspace(ViewWorkspace workspace)
            : base(workspace)
        {
            UpdatedMemberList = new List<PatchDocument<WorkspacePatchValueEmail>>();
            _validator = new UpdateWorkspaceValidation();
        }

        public PatchDocument<string> GetNameChange => UpdatedWorkspaceName;

        public List<PatchDocument<WorkspacePatchValueEmail>> GetMemberUpdates => UpdatedMemberList;

        public static UpdateWorkspace Create(ViewWorkspace workspace)
        {
            Guard.ForNullObject(workspace, nameof(workspace));
            return new UpdateWorkspace(workspace);
        }

        public ViewWorkspace ChangeName(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));
            UpdatedWorkspaceName = PatchDocument<string>
                .Create(OperationType.Replace, Constants.PatchOptions.Workspace.Name)
                .ChangeValue(name);
            return this;
        }

        public ViewWorkspace AddMember(string email)
        {
            Guard.ForNullOrEmptyOrWhitespace(email, nameof(email));
            if (this.IsNew()) throw new InvalidOperationException("");
            UpdatedMemberList.Add(PatchDocument<WorkspacePatchValueEmail>
                .Create(OperationType.Add, Constants.PatchOptions.Workspace.Member)
                .ChangeValue(
                    new WorkspacePatchValueEmail
                    {
                        Email = email
                    }));

            return this;
        }

        public ViewWorkspace RemoveMember(string email)
        {
            Guard.ForNullOrEmptyOrWhitespace(email, nameof(email));
            if (this.IsNew()) throw new InvalidOperationException("");
            UpdatedMemberList.Add(PatchDocument<WorkspacePatchValueEmail>
                .Create(OperationType.Remove, Constants.PatchOptions.Workspace.Member)
                .ChangeValue(
                    new WorkspacePatchValueEmail
                    {
                        Email = email
                    }));
            return this;
        }

        public async Task<bool> IsValid(CancellationToken token)
        {
            var validation = await _validator.ValidateAsync(this, token);
            if (validation.IsValid) return true;
            throw new ValidationException(validation.Errors);
        }

        public object ToJsonPatch()
        {
            return null;
        }
    }
}