using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum FieldType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Field_Date")] [EnumMember(Value = "date")]
        Date,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Dropdown")] [EnumMember(Value = "dropdown")]
        Dropdown,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Email")] [EnumMember(Value = "email")]
        Email,

        [Display(ResourceType = typeof(EnumText), Name = "Field_PhoneNumber")] [EnumMember(Value = "phone_number")]
        PhoneNumber,

        [Display(ResourceType = typeof(EnumText), Name = "Field_FileUpload")] [EnumMember(Value = "file_upload")]
        FileUpload,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Group")] [EnumMember(Value = "group")]
        Group,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Legal")] [EnumMember(Value = "legal")]
        Legal,

        [Display(ResourceType = typeof(EnumText), Name = "Field_LongText")] [EnumMember(Value = "long_text")]
        LongText,

        [Display(ResourceType = typeof(EnumText), Name = "Field_MultipleChoice")]
        [EnumMember(Value = "multiple_choice")]
        MultipleChoice,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Number")] [EnumMember(Value = "number")]
        Number,

        [Display(ResourceType = typeof(EnumText), Name = "Field_OpinionScale")] [EnumMember(Value = "opinion_scale")]
        OpinionScale,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Payment")] [EnumMember(Value = "payment")]
        Payment,

        [Display(ResourceType = typeof(EnumText), Name = "Field_PictureChoice")] [EnumMember(Value = "picture_choice")]
        PictureChoice,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Rating")] [EnumMember(Value = "rating")]
        Rating,

        [Display(ResourceType = typeof(EnumText), Name = "Field_ShortText")] [EnumMember(Value = "short_text")]
        ShortText,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Statement")] [EnumMember(Value = "statement")]
        Statement,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Website")] [EnumMember(Value = "website")]
        Website,

        [Display(ResourceType = typeof(EnumText), Name = "Field_YesNo")] [EnumMember(Value = "yes_no")]
        YesNo
    }
}