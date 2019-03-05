using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum ActionType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Action_Jump")]
        Jump,

        [Display(ResourceType = typeof(EnumText), Name = "Action_Add")]
        Add,

        [Display(ResourceType = typeof(EnumText), Name = "Action_Subtract")]
        Substract,

        [Display(ResourceType = typeof(EnumText), Name = "Action_Multiply")]
        Multiply,

        [Display(ResourceType = typeof(EnumText), Name = "Action_Divide")]
        Divide
    }
}