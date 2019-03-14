using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Typeform.Sdk.CSharp.Models.Workspaces.Validations;

namespace Typeform.Sdk.CSharp.Builders
{
    /// <summary>
    /// </summary>
    public class WorkspaceUpdateBuilder : IIsValidatable<UpdateWorkspaceValidation, UpdateWorkspace>,
        IToJson
    {
        private UpdateWorkspace _updateWorkspace;

        private WorkspaceUpdateBuilder()
        {
        }

        #region Implementation of IIsValidatable

        /// <inheritdoc />
        /// <summary>
        ///     Validates the model.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> IsValid(CancellationToken token = default)
        {
            var validator = new UpdateWorkspaceValidation();
            var validation = await validator.ValidateAsync(_updateWorkspace, token);
            if (validation.IsValid) return true;
            throw new ValidationException(validation.Errors);
        }

        #endregion

        #region Implementation of IToJson

        /// <summary>
        ///     Convert data to JSON Patch Model.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            var list = new List<dynamic>();
            list.AddRange(_updateWorkspace.UpdateMemberOptions);
            list.Add(_updateWorkspace.UpdateWorkspaceName);
            return JsonConvert.SerializeObject(list);
        }

        #endregion

        /// <summary>
        ///     Create a new instance of the WorkspaceUpdateBuilder.
        /// </summary>
        /// <param name="workspaceId">The workspace id.</param>
        /// <returns></returns>
        public static WorkspaceUpdateBuilder Create(string workspaceId)
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceId, nameof(workspaceId));

            return new WorkspaceUpdateBuilder
            {
                _updateWorkspace = UpdateWorkspace.Create(workspaceId)
            };
        }

        /// <summary>
        ///     Change the name of the workspace.
        /// </summary>
        /// <param name="name">New name.</param>
        /// <returns></returns>
        public WorkspaceUpdateBuilder ReplaceName(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));
            _updateWorkspace.ChangeWorkspaceName(name);
            return this;
        }

        /// <summary>
        ///     Add new member email address.
        /// </summary>
        /// <param name="emailAddress">Email Address.</param>
        /// <returns></returns>
        public WorkspaceUpdateBuilder AddMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));
            _updateWorkspace.AddMember(emailAddress);
            return this;
        }

        /// <summary>
        ///     Remove member email address.
        /// </summary>
        /// <param name="emailAddress">Email Address.</param>
        /// <returns></returns>
        public WorkspaceUpdateBuilder RemoveMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));
            _updateWorkspace.RemoveMember(emailAddress);
            return this;
        }

        /// <summary>
        ///     Build the Update Workspace.
        /// </summary>
        /// <returns></returns>
        public UpdateWorkspace Build()
        {
            return _updateWorkspace;
        }
    }
}