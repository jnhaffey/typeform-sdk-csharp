using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class ViewWorkspace : IToJson, IFromJson<ViewWorkspace>
    {
        /// <summary>
        ///     Unique identifier for the workspace.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Name of the workspace.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     If the default workspace, true. Otherwise, false.
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; }

        /// <summary>
        ///     If the workspace is shared with a team, true. Otherwise, false.
        /// </summary>
        [JsonProperty("shared")]
        public bool Shared { get; set; }

        /// <summary>
        ///     Link and count of typeforms in the workspace.
        /// </summary>
        [JsonProperty("forms")]
        public WorkspaceForms Forms { get; set; }

        /// <summary>
        ///     Link to the workspace.
        /// </summary>
        [JsonProperty("self")]
        public HrefObject SelfLink { get; set; }

        /// <summary>
        ///     List of members.
        /// </summary>
        [JsonProperty("members")]
        public List<WorkspaceMember> Members { get; set; }

        #region Implementation of IFromJson<out ViewWorkspace>

        /// <summary>
        ///     Convert JSON data to a View Workspace Model.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public ViewWorkspace FromJson(string jsonData)
        {
            Guard.ForNullOrEmptyOrWhitespace(jsonData, nameof(jsonData));
            var deserializedObject = JsonConvert.DeserializeObject<ViewWorkspace>(jsonData);
            Id = deserializedObject.Id;
            Name = deserializedObject.Name;
            Default = deserializedObject.Default;
            Shared = deserializedObject.Shared;
            Forms = deserializedObject.Forms;
            SelfLink = deserializedObject.SelfLink;
            Members = deserializedObject.Members;
            return this;
        }

        #endregion

        #region Implementation of IToJson

        /// <summary>
        ///     Convert this Workspace to JSON.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion

        /// <summary>
        ///     Compare a workspace model with this workspace to generate a update workspace model.
        /// </summary>
        /// <param name="compareWith"></param>
        /// <returns></returns>
        public UpdateWorkspace GenerateUpdateWorkspaceModel(ViewWorkspace compareWith)
        {
            var updateModel = UpdateWorkspace.Create(Id);

            if (!Name.Equals(compareWith.Name)) updateModel.ChangeWorkspaceName(compareWith.Name);

            // Remove Old Members
            foreach (var member in Members)
                if (!compareWith.Members.Any(x => x.Email.Equals(member.Email)))
                    updateModel.RemoveMember(member.Email);

            // Add New Members
            foreach (var member in compareWith.Members)
                if (!Members.Any(x => x.Email.Equals(member.Email)))
                    updateModel.AddMember(member.Email);

            return updateModel;
        }
    }
}