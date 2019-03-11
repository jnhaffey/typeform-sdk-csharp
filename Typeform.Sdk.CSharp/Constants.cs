namespace Typeform.Sdk.CSharp
{
    public static class Constants
    {
        /// <summary>
        ///     Base URL for Typeform.
        /// </summary>
        public const string BaseUrl = "https://api.typeform.com/";

        internal static class Headers
        {
            internal const string ContentType = "Content-Type";
        }

        internal static class MimeTypes
        {
            internal const string TextPlain = "text/plain";
            internal const string TextHtml = "text/html";
            internal const string ImageJpeg = "image/jpeg";
            internal const string ImagePng = "image/png";
            internal const string AudioMpeg = "audio/mpeg";
            internal const string AudioOgg = "audio/ogg";
            internal const string AudioStar = "audio/*";
            internal const string VideoMp4 = "video/mp4";
            internal const string ApplicationStar = "application/*";
            internal const string ApplicationJson = "application/json";
            internal const string ApplicationJavascript = "application/javascript";
            internal const string ApplicationEcmascript = "application/ecmascript";
            internal const string ApplicationOctetStream = "application/octetstream";
        }

        internal static class DebugNames
        {
            internal const string ApiResults = "API Results";
            internal const string ApiContent = "API Content";
            internal const string JsonPatch = "JSON Patch";
        }
    }
}