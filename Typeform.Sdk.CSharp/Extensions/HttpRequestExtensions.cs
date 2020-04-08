using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Flurl.Http;
using Microsoft.AspNetCore.Http;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string SignatureHeader = "Typeform-Signature";
        private const int DefaultBufferSize = 1024;
        private static readonly Encoding encoding = new UTF8Encoding();

        public static async Task<Result<string>> ValidateAndRetrievePayload(this HttpRequest request, string key)
        {
            if (request.Headers.Keys.Contains(SignatureHeader))
            {
                var headerValue = request.Headers[SignatureHeader].FirstOrDefault();
                if (string.IsNullOrWhiteSpace(headerValue))
                    return Result.Failure<string>($"'{SignatureHeader}' has not value.");

                using (var reader = new StreamReader(request.Body, encoding))
                {
                    var json = await reader.ReadToEndAsync();
                    var payload = encoding.GetBytes(json);
                    using (var hmac256 = new HMACSHA256(encoding.GetBytes(key)))
                    {
                        var hashPayload = hmac256.ComputeHash(payload);
                        var base64String = Convert.ToBase64String(hashPayload);
                        var hashResult = $"sha256={base64String}";
                        if (hashResult.Equals(headerValue))
                            return Result.Success(json);
                        return Result.Failure<string>(
                            $"'{SignatureHeader}' does not match. Header: `{headerValue}` | Hash: `{hashResult}`");
                    }
                }
            }

            return Result.Failure<string>($"'{SignatureHeader}' Header not found.");
        }

        public static async Task<Result<string>> ValidateAndRetrievePayload(this HttpRequestMessage request, string key)
        {
            var headerValue = request.GetHeaderValue(SignatureHeader);
            if (string.IsNullOrWhiteSpace(headerValue))
                return Result.Failure<string>($"'{SignatureHeader}' Header not found or empty.");

            var json = await request.Content.ReadAsStringAsync();
            var payload = encoding.GetBytes(json);
            using (var hmac256 = new HMACSHA256(encoding.GetBytes(key)))
            {
                var hashPayload = hmac256.ComputeHash(payload);
                var base64String = Convert.ToBase64String(hashPayload);
                var hashResult = $"sha256={base64String}";
                if (hashResult.Equals(headerValue))
                    return Result.Success(json);
                return Result.Failure<string>(
                    $"'{SignatureHeader}' does not match. Header: `{headerValue}` | Hash: `{hashResult}`");
            }
        }
    }
}