using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Flurl.Http;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class HttpRequestExtensions
    {
        private const string SignatureHeader = "Typeform-Signature";

        public static async Task<Result<string>> ValidateAndRetrievePayload(this HttpRequestMessage request, string key)
        {
            var headerValue = request.GetHeaderValue(SignatureHeader);
            if (string.IsNullOrWhiteSpace(headerValue))
                return Result.Failure<string>($"'{SignatureHeader}' Header not found or empty.");

            var payload = await request.Content.ReadAsByteArrayAsync();
            var byteKey = GetBytes(key);
            using (var hmac256 = new HMACSHA256(byteKey))
            {
                var hashPayload = hmac256.ComputeHash(payload);
                var base64String = Convert.ToBase64String(hashPayload);
                var hashResult = $"sha256={base64String}";
                if (hashResult.Equals(headerValue))
                    return Result.Success(await request.Content.ReadAsStringAsync());
                return Result.Failure<string>(
                    $"'{SignatureHeader}' does not match. Header: `{headerValue}` | Hash: `{hashResult}`");
            }
        }

        private static byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}