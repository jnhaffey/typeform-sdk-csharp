namespace Typeform.Sdk.CSharp.Exceptions
{
    public static class BooleanExtensions
    {
        public static string ToLowerString(this bool source)
        {
            return source.ToString().ToLowerInvariant();
        }
    }
}