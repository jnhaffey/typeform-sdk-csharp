using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Linq;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Builders
{
    /// <summary>
    /// </summary>
    public class WorkspaceUpdateBuilder
    {
        private const string Name = "/name";
        private const string Member = "/member";
        private readonly List<Patch<string>> _memberChanges;
        private Patch<string> _nameChange;

        private WorkspaceUpdateBuilder()
        {
            _memberChanges = new List<Patch<string>>();
        }

        /// <summary>
        ///     The Workspace Id to be use.
        /// </summary>
        public string WorkspaceId { get; private set; }

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
                WorkspaceId = workspaceId
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

            _nameChange = new Patch<string> {Operation = OperationType.Replace, Path = Name, Value = name};
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

            _memberChanges.Add(new Patch<string> {Operation = OperationType.Add, Path = Member, Value = emailAddress});
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

            _memberChanges.Add(
                new Patch<string> {Operation = OperationType.Remove, Path = Member, Value = emailAddress});
            return this;
        }

        /// <summary>
        ///     Convert data to JSON Patch Model.
        /// </summary>
        /// <returns></returns>
        public object ToJsonPatch()
        {
            var patchData = new List<JObject>();

            if (_nameChange != null)
            {
                dynamic nameChange = new JObject();
                nameChange.op = _nameChange.Operation.ToString();
                nameChange.path = _nameChange.Path;
                nameChange.value = _nameChange.Value;
                patchData.Add(nameChange);
            }

            foreach (var mbrChange in _memberChanges)
            {
                dynamic memberChange = new JObject();
                memberChange.op = mbrChange.Operation.ToString();
                memberChange.path = mbrChange.Path;
                memberChange.value = new JObject();
                memberChange.value.email = mbrChange.Value;
                patchData.Add(memberChange);
            }

            return new JArray(patchData);
        }
    }
}