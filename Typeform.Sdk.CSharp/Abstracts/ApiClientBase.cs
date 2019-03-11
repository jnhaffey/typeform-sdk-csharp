namespace Typeform.Sdk.CSharp.Abstracts
{
    public abstract class ApiClientBase
    {
        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        protected ApiClientBase(string apiKey = "")
        {
            ApiKey = apiKey;
        }

        /// <summary>
        ///     API Key to use.
        /// </summary>
        public string ApiKey { get; private set; }

        /// <summary>
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns></returns>
        public void Initialize(string apiKey)
        {
            Guard.ForNullOrEmptyOrWhitespace(apiKey, nameof(apiKey));

            ApiKey = apiKey;
        }
    }
}