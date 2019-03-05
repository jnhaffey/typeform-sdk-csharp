using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum ButtonModeType
    {
        [Display(ResourceType = typeof(EnumText), Name = "ButtonMode_Reload")]
        Reload,

        [Display(ResourceType = typeof(EnumText), Name = "ButtonMode_Redirect")]
        Redirect
    }
}