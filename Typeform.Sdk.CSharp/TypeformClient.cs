namespace Typeform.Sdk.CSharp
{
    public sealed class TypeformClient
    {
        private readonly string _apiKey;

        public TypeformClient(string apiKey)
        {
            _apiKey = apiKey;
        }
    }
}