using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Workspaces;
using Typeform.Sdk.CSharp.Models.Workspaces.Validations;

namespace Typeform.Sdk.CSharp.Builders
{
    /// <summary>
    /// </summary>
    public class WorkspaceBuilder : IIsValidatable<CreateWorksapceValidation, CreateWorkspace>,
        IBuilder<CreateWorkspace>
    {
        private readonly CreateWorkspace _workspace;

        #region Private Constructors

        private WorkspaceBuilder(string name)
        {
            _workspace = CreateWorkspace.Create(name);
        }

        #endregion

        #region Implementation of IBuilder<CreateWorkspace>

        /// <summary>
        ///     Build the Create Workspace model.
        /// </summary>
        /// <returns></returns>
        public CreateWorkspace Build()
        {
            return CreateWorkspace.Create(_workspace.Name);
        }

        #endregion

        #region Implementation of IIsValidatable<CreateWorksapceValidation,CreateWorkspace>

        /// <summary>
        ///     Checks if the current configuration of the Workspace builder is valid.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<bool> IsValid(CancellationToken token = default)
        {
            var validator = new CreateWorksapceValidation();
            var validation = await validator.ValidateAsync(_workspace);
            if (validation.IsValid) return true;

            throw new ValidationException(validation.Errors);
        }

        #endregion

        #region Static Create Methods

        /// <summary>
        ///     Create a new instance of the WorkspaceBuilder using a Workspace name.
        /// </summary>
        /// <param name="name">The workspace name.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WorkspaceBuilder Create(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));

            return new WorkspaceBuilder(name);
        }

        /// <summary>
        ///     Create a new instance of the WorkspaceBuilder using JSON Data.
        /// </summary>
        /// <param name="rawJson">Raw JSON data that represents a workspace.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static WorkspaceBuilder CreateFrom(string rawJson)
        {
            Guard.ForNullOrEmptyOrWhitespace(rawJson, nameof(rawJson));
            var model = JsonConvert.DeserializeObject<ViewWorkspace>(rawJson);
            if (model != null) return new WorkspaceBuilder(model.Name);

            throw new ArgumentException("The json value provided was not valid.", nameof(rawJson));
        }

        /// <summary>
        ///     Create a new instance of the WorkspaceBuilder using a workspace model.
        /// </summary>
        /// <param name="workspaceModel">The workspace model to work with.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static WorkspaceBuilder CreateFrom(ViewWorkspace workspaceModel)
        {
            Guard.ForNullValue(workspaceModel, nameof(workspaceModel));
            return new WorkspaceBuilder(workspaceModel.Name);
        }

        #endregion
    }
}