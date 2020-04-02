namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class CreateWorkspace : ViewWorkspace
    {
        private CreateWorkspace(string name)
            : base(name)
        {
        }

        public static CreateWorkspace Create(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));
            return new CreateWorkspace(name);
        }

        public ViewWorkspace ChangeName(string name)
        {
            Guard.ForNullOrEmptyOrWhitespace(name, nameof(name));
            Name = name;

            return this;
        }
    }
}