using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class ViewWorkspace : IHasId, IToJson
    {
        private ViewWorkspace()
        {
            Members = new List<Member>();
        }

        protected ViewWorkspace(string name)
        {
            Members = new List<Member>();
            Name = name;
        }

        protected ViewWorkspace(ViewWorkspace workspace)
        {
            Id = workspace.Id;
            Name = workspace.Name;
            Default = workspace.Default;
            Shared = workspace.Shared;
            Forms = workspace.Forms;
            SelfLink = workspace.SelfLink;
            Members = workspace.Members;
        }

        /// <summary>
        ///     Name of the workspace.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; protected set; }

        /// <summary>
        ///     If the default workspace, true. Otherwise, false.
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; private set; }

        /// <summary>
        ///     If the workspace is shared with a team, true. Otherwise, false.
        /// </summary>
        [JsonProperty("shared")]
        public bool Shared { get; private set; }

        /// <summary>
        ///     Link and count of typeforms in the workspace.
        /// </summary>
        [JsonProperty("forms")]
        public Forms Forms { get; private set; }

        /// <summary>
        ///     Link to the workspace.
        /// </summary>
        [JsonProperty("self")]
        public HrefObject SelfLink { get; private set; }

        /// <summary>
        ///     List of members.
        /// </summary>
        [JsonProperty("members")]
        public List<Member> Members { get; private set; }

        #region Implementation of IHasId

        /// <summary>
        ///     Unique identifier for the workspace.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        #endregion

        #region Implementation of IToJson

        /// <summary>
        ///     Convert this ViewWorkspace to JSON.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        #endregion

        #region Implementation of IFromJson<out ViewWorkspace>

        /// <summary>
        ///     Convert JSON data to a View ViewWorkspace Model.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static ViewWorkspace CreateFromJson(string jsonData)
        {
            Guard.ForNullOrEmptyOrWhitespace(jsonData, nameof(jsonData));
            var deserializedObject = JsonConvert.DeserializeObject<ViewWorkspace>(jsonData);
            return new ViewWorkspace
            {
                Id = deserializedObject.Id,
                Name = deserializedObject.Name,
                Default = deserializedObject.Default,
                Shared = deserializedObject.Shared,
                Forms = deserializedObject.Forms,
                SelfLink = deserializedObject.SelfLink,
                Members = deserializedObject.Members
            };
        }

        #endregion

        /// <summary>
        ///     Compare another workspace model with this workspace to generate a update workspace model.
        /// </summary>
        /// <param name="compareWith"></param>
        /// <returns></returns>
        public UpdateWorkspace GenerateUpdateWorkspaceModel(ViewWorkspace compareWith)
        {
            var updateModel = UpdateWorkspace.Create(this);

            if (!Name.Equals(compareWith.Name)) updateModel.ChangeName(compareWith.Name);

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