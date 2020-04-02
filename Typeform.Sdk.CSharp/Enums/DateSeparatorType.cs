using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum DateSeparatorType
    {
        [Display(ResourceType = typeof(EnumText), Name = "DateSeparator_Slash")]
        Slash,

        [Display(ResourceType = typeof(EnumText), Name = "DateSeparator_Dash")]
        Dash,

        [Display(ResourceType = typeof(EnumText), Name = "DateSeparator_Dot")]
        Dot
    }
}