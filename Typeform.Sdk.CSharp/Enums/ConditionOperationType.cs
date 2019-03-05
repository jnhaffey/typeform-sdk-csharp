using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum ConditionOperationType
    {
        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_BeginsWith")]
        BeginsWith,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_EndsWith")]
        EndsWith,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_Contains")]
        Contains,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_NotContains")]
        NotContains,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_LowerThan")]
        LowerThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_LowerEqualThan")]
        LowerEqualThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_GreaterThan")]
        GreaterThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_GreaterEqualThan")]
        GreaterEqualThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_Is")]
        Is,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_IsNot")]
        IsNot,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_Equal")]
        Equal,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_NotEqual")]
        NotEqual,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_Always")]
        Always,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_On")]
        On,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_NotOn")]
        NotOn,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_EarlierThan")]
        EarlierThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_EarlierThanOrOn")]
        EarlierThanOrOn,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_LaterThan")]
        LaterThan,

        [Display(ResourceType = typeof(EnumText), Name = "ConditionOperation_LaterThanOrOn")]
        LaterThanOrOn
    }
}