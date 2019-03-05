using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum ProgressBarType
    {
        [Display(ResourceType = typeof(EnumText), Name = "ProgressBar_Proportion")]
        Proportion,

        [Display(ResourceType = typeof(EnumText), Name = "ProgressBar_Percentage")]
        Percentage
    }
}