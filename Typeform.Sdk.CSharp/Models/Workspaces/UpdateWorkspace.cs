using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Typeform.Sdk.CSharp.Models.Shared;
using static Typeform.Sdk.CSharp.Constants.PatchOptions;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class UpdateWorkspace
    {
        private readonly List<PatchDocument<WorkspacePatchValueEmail>> _updateMemberOptions;

        private UpdateWorkspace()
        {
            _updateMemberOptions = new List<PatchDocument<WorkspacePatchValueEmail>>();
        }

        public IReadOnlyList<PatchDocument<WorkspacePatchValueEmail>> UpdateMemberOptions => _updateMemberOptions;

        public PatchDocument<string> UpdateWorkspaceName { get; private set; }

        /// <summary>
        ///     The ViewWorkspace Id to be use.
        /// </summary>
        public string WorkspaceId { get; private set; }

        public static UpdateWorkspace Create(string workspaceId)
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceId, nameof(workspaceId));
            return new UpdateWorkspace
            {
                WorkspaceId = workspaceId
            };
        }

        /// <summary>
        ///     Add patch operation to add/update a name change for the workspace.
        /// </summary>
        /// <param name="workspaceName"></param>
        /// <returns></returns>
        public UpdateWorkspace ChangeWorkspaceName(string workspaceName)
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceName, nameof(workspaceName));
            if (UpdateWorkspaceName == null)
                UpdateWorkspaceName = PatchDocument<string>.Create(OperationType.Replace, Workspace.Name)
                    .ChangeValue(workspaceName);
            else
                UpdateWorkspaceName.ChangeValue(workspaceName);
            return this;
        }

        /// <summary>
        ///     Add patch operation to add a member to the workspace.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public UpdateWorkspace AddMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));

            var currentRecord = _updateMemberOptions.FirstOrDefault(x =>
                x.Operation.Equals(OperationType.Add) &&
                x.Path.Equals(Workspace.Member) &&
                x.Value.Email == emailAddress);
            if (currentRecord == null)
                _updateMemberOptions.Add(PatchDocument<WorkspacePatchValueEmail>.Create(OperationType.Add,
                        Workspace.Member)
                    .ChangeValue(new WorkspacePatchValueEmail {Email = emailAddress}));

            return this;
        }

        /// <summary>
        ///     Add patch operator to remove a member from the workspace.
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public UpdateWorkspace RemoveMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));

            var currentRecord = _updateMemberOptions.FirstOrDefault(x =>
                x.Operation.Equals(OperationType.Remove) &&
                x.Path.Equals(Workspace.Member) &&
                x.Value.Email == emailAddress);
            if (currentRecord == null)
                _updateMemberOptions.Add(
                    PatchDocument<WorkspacePatchValueEmail>.Create(OperationType.Remove, Workspace.Member)
                        .ChangeValue(new WorkspacePatchValueEmail {Email = emailAddress}));

            return this;
        }
    }
}