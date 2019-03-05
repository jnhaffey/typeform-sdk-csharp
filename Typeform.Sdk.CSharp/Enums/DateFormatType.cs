using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum DateFormatType
    {
        [Display(ResourceType = typeof(EnumText), Name = "DateFormat_MonthDayYear")]
        MMDDYYYY,
        [Display(ResourceType = typeof(EnumText), Name = "DateFormat_DayMonthYear")]
        DDMMYYYY,
        [Display(ResourceType = typeof(EnumText), Name = "DateFormat_YearMonthDay")]
        YYYYMMDD
    }
}