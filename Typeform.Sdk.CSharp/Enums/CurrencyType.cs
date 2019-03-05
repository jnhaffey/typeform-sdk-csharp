using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum CurrencyType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Currency_AUD")]
        AUD,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_BRL")]
        BRL,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_CAD")]
        CAD,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_CHF")]
        CHF,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_DKK")]
        DKK,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_EUR")]
        EUR,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_GBP")]
        GBP,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_MXN")]
        MXN,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_NOK")]
        NOK,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_SEK")]
        SEK,

        [Display(ResourceType = typeof(EnumText), Name = "Currency_USD")]
        USD
    }
}