using System.Runtime.Serialization;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum FormAnswerType
    {
        [EnumMember(Value = "text")] Text,
        [EnumMember(Value = "email")] Email,
        [EnumMember(Value = "choice")] Choice,
        [EnumMember(Value = "choices")] Choices,
        [EnumMember(Value = "date")] Date,
        [EnumMember(Value = "boolean")] Boolean,
        [EnumMember(Value = "number")] Number,
        [EnumMember(Value = "file_url")] FileUrl,
        [EnumMember(Value = "payment")] Payment,
        [EnumMember(Value = "phone_number")] PhoneNumber,
    }
}