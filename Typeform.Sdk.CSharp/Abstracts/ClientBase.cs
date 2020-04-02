namespace Typeform.Sdk.CSharp.Abstracts
{
    public abstract class ClientBase
    {
        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        protected ClientBase(string apiKey = "")
        {
            Guard.ForNullOrEmptyOrWhitespace(apiKey, nameof(apiKey));
            ApiKey = apiKey;
        }

        /// <summary>
        ///     API Key to use.
        /// </summary>
        internal string ApiKey { get; }
    }
}