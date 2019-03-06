namespace Typeform.Sdk.CSharp.Extensions
{
    public static class StringExtensions
    {
        public static string ReplaceValidationPlaceHolders(this string value, string propertyName, string propertyValue)
        {
            return value.Replace("{PropertyName}", propertyName).Replace("{PropertyValue}", propertyValue);
        }
    }
}