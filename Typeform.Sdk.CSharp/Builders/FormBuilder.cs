using System.Threading.Tasks;
using FluentValidation;
using Typeform.Sdk.CSharp.Models;
using Typeform.Sdk.CSharp.Resources;
using Typeform.Sdk.CSharp.Validations;

namespace Typeform.Sdk.CSharp.Builders
{
    public sealed class FormBuilder
    {
        private readonly Form _form;

        /// <summary>
        ///     Create an instance of the Form builder.
        /// </summary>
        /// <param name="title">Title of the form that is going to be build.</param>
        public FormBuilder(string title)
        {
            _form = new Form {Title = title};
        }

        public FormBuilder AddSettings(string settingOptions)
        {
            return this;
        }

        public FormBuilder AddTheme(string themeUrl)
        {
            Guard.ForNullOrEmptyOrWhitespace(themeUrl, nameof(themeUrl));
            // TODO : Guard for URL

            _form.Theme = themeUrl;
            return this;
        }

        public FormBuilder AddWorkspace(string workspaceOptions)
        {
            return this;
        }

        /// <summary>
        ///     Add Hidden Properties to a form.
        /// </summary>
        /// <param name="hiddenProperties">Array of strings that will be added as Hidden Properties to the form.</param>
        /// <returns></returns>
        public FormBuilder AddHiddenProperties(params string[] hiddenProperties)
        {
            foreach (var hiddenProperty in hiddenProperties)
            {
                Guard.ForNullOrEmptyOrWhitespace(hiddenProperty, nameof(hiddenProperties));
                Guard.ForDuplicateItemsInList(hiddenProperty, nameof(hiddenProperties), _form.Hidden,
                    nameof(_form.Hidden));
            }

            _form.Hidden.AddRange(hiddenProperties);
            return this;
        }

        public FormBuilder AddVariables(string variableOptions)
        {
            return this;
        }

        public FormBuilder AddWelcomeScreen(string welcomeScreenOptions)
        {
            return this;
        }

        public FormBuilder AddThankYouScreen(string thankYouScreenOptions)
        {
            return this;
        }

        public FormBuilder AddField(string fieldOptions)
        {
            return this;
        }

        public FormBuilder AddLogic(string logicOptions)
        {
            return this;
        }

        public async Task<Form> Build()
        {
            var validator = new FormValidation();
            var validation = await validator.ValidateAsync(_form);
            if (validation.IsValid) return _form;
            throw new ValidationException(ErrorMessages.Validation_FormCreationException, validation.Errors);
        }
    }
}