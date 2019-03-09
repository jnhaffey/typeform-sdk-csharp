using Microsoft.Extensions.Logging;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class LoggingExtensions
    {
        /// <summary>
        ///     Logs the value of the caller to the url.
        ///     Format: Calling URL: {urlCalling}
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="urlCalling"></param>
        public static void LogUrlCall(this ILogger logger, string urlCalling)
        {
            logger.LogInformation("Calling URL: {urlCalling}", urlCalling);
        }

        /// <summary>
        ///     Logs the value of the result data from a call.
        ///     Format: Call Results: {data}
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="logger"></param>
        /// <param name="data"></param>
        public static void DebugRawResults<TData>(this ILogger logger, TData data)
        {
            logger.LogDebug("Call Results: {@data}", data);
        }
    }
}