using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Typeform.Sdk.CSharp.Models.Workspaces.Validations;

namespace Typeform.Sdk.CSharp.Modifiers
{
    public class WorkspaceModifier : IIsValidatable<UpdateWorkspaceValidation, UpdateWorkspace>,
        IModifier<UpdateWorkspace>
    {
        private readonly ViewWorkspace _originalWorkSpace;
        private readonly UpdateWorkspace _updateWorkspace;

        private WorkspaceModifier(ViewWorkspace originalWorkspace)
        {
            _originalWorkSpace = originalWorkspace;
            _updateWorkspace = UpdateWorkspace.Create(originalWorkspace.Id);
        }

        #region Implementation of IIsValidatable<UpdateWorkspaceValidation,UpdateWorkspace>

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

        #region Implementation of IModifier<out UpdateWorkspace>

        /// <summary>
        ///     Creates the Update Workspace Model.
        /// </summary>
        /// <returns></returns>
        public UpdateWorkspace Modify()
        {
            return _updateWorkspace;
        }

        #endregion

        /// <summary>
        ///     Create an instance of the Workspace Modifier object.
        /// </summary>
        /// <param name="workspace"></param>
        /// <returns></returns>
        public static WorkspaceModifier Create(ViewWorkspace workspace)
        {
            Guard.ForNullValue(workspace, nameof(workspace));

            return new WorkspaceModifier(workspace);
        }

        /// <summary>
        ///     Create an instance of the Workspace Modifier object.
        /// </summary>
        /// <param name="workspaceJson"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static WorkspaceModifier Create(string workspaceJson)
        {
            Guard.ForNullOrEmptyOrWhitespace(workspaceJson, nameof(workspaceJson));
            var model = JsonConvert.DeserializeObject<ViewWorkspace>(workspaceJson);
            if (model != null) return Create(model);
            throw new ArgumentException("The json value provided was not valid.", nameof(workspaceJson));
        }

        /// <summary>
        ///     Change the name of the workspace.
        /// </summary>
        /// <param name="name">New name.</param>
        /// <returns></returns>
        public WorkspaceModifier ReplaceName(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));
            if (!name.Equals(_originalWorkSpace.Name)) _updateWorkspace.ChangeWorkspaceName(name);
            return this;
        }

        /// <summary>
        ///     Add new member email address.
        /// </summary>
        /// <param name="emailAddress">Email Address.</param>
        /// <returns></returns>
        public WorkspaceModifier AddMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));
            Guard.ForInvalidEmailForm(emailAddress, nameof(emailAddress));
            if (_originalWorkSpace.Members.Any(x => !x.Email.Equals(emailAddress)))
                _updateWorkspace.AddMember(emailAddress);
            return this;
        }

        /// <summary>
        ///     Remove member email address.
        /// </summary>
        /// <param name="emailAddress">Email Address.</param>
        /// <returns></returns>
        public WorkspaceModifier RemoveMember(string emailAddress)
        {
            Guard.ForNullOrEmptyOrWhitespace(emailAddress, nameof(emailAddress));
            Guard.ForInvalidEmailForm(emailAddress, nameof(emailAddress));
            if (_originalWorkSpace.Members.Any(x => x.Email.Equals(emailAddress)))
                _updateWorkspace.RemoveMember(emailAddress);
            return this;
        }

        /// <summary>
        ///     Convert data to JSON Patch Model.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string ToJsonPatch()
        {
            var list = new List<dynamic>();
            list.AddRange(_updateWorkspace.UpdateMemberOptions);
            list.Add(_updateWorkspace.UpdateWorkspaceName);
            return JsonConvert.SerializeObject(list);
        }
    }
}