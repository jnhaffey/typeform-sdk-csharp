using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum FieldType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Field_Date")]
        Date,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Dropdown")]
        Dropdown,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Email")]
        Email,

        [Display(ResourceType = typeof(EnumText), Name = "Field_FileUpload")]
        FileUpload,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Group")]
        Group,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Legal")]
        Legal,

        [Display(ResourceType = typeof(EnumText), Name = "Field_LongText")]
        LongText,

        [Display(ResourceType = typeof(EnumText), Name = "Field_MultipleChoice")]
        MultipleChoice,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Number")]
        Number,

        [Display(ResourceType = typeof(EnumText), Name = "Field_OpinionScale")]
        OpinionScale,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Payment")]
        Payment,

        [Display(ResourceType = typeof(EnumText), Name = "Field_PictureChoice")]
        PictureChoice,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Rating")]
        Rating,

        [Display(ResourceType = typeof(EnumText), Name = "Field_ShortText")]
        ShortText,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Statement")]
        Statement,

        [Display(ResourceType = typeof(EnumText), Name = "Field_Website")]
        Website,

        [Display(ResourceType = typeof(EnumText), Name = "Field_YesNo")]
        YesNo
    }
}