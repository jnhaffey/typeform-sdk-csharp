using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum LogicActionType
    {
        [Display(ResourceType = typeof(EnumText), Name = "LogicAction_Field")]
        Field,

        [Display(ResourceType = typeof(EnumText), Name = "LogicAction_Hidden")]
        Hidden
    }
}