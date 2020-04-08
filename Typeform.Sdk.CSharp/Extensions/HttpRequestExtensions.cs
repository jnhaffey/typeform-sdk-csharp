using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string SignatureHeader = "Typeform-Signature";
        private const int DefaultBufferSize = 1024;
        private static readonly Encoding encoding = new UTF8Encoding();

        public static async Task<Result> IsWebhookResponseValid(this HttpRequest request, string key)
        {
            if (request.Headers.Keys.Contains(SignatureHeader))
            {
                var headerValue = request.Headers[SignatureHeader].FirstOrDefault();
                if (string.IsNullOrWhiteSpace(headerValue))
                    return Result.Failure($"'{SignatureHeader}' has not value.");

                var json = await request.ReadAsStringAsync();
                var payload = encoding.GetBytes(json);
                using (var hmac256 = new HMACSHA256(encoding.GetBytes(key)))
                {
                    var hashPayload = hmac256.ComputeHash(payload);
                    var base64String = Convert.ToBase64String(hashPayload);
                    var hashResult = $"sha256={base64String}";
                    if (hashResult.Equals(headerValue))
                        return Result.Success();
                    return Result.Failure(
                        $"'{SignatureHeader}' does not match. Header: `{headerValue}` | Hash: `{hashResult}`");
                }
            }

            return Result.Failure($"'{SignatureHeader}' Header not found.");
        }

        private static async Task<string> ReadAsStringAsync(this HttpRequest request)
        {
            request.EnableRewind();

            string result = null;
            using (var reader = new StreamReader(
                request.Body,
                Encoding.UTF8,
                true,
                DefaultBufferSize,
                true))
            {
                result = await reader.ReadToEndAsync();
            }

            request.Body.Seek(0, SeekOrigin.Begin);

            return result;
        }
    }
}