using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class CreateWorkspace
    {
        private CreateWorkspace()
        {
        }

        /// <summary>
        ///     Name of the new workspace.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        public static CreateWorkspace Create(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));

            return new CreateWorkspace
            {
                Name = name
            };
        }
    }
}