using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum AttachmentType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Attachment_Image")]
        Image,

        [Display(ResourceType = typeof(EnumText), Name = "Attachment_Video")]
        Video
    }
}