using System.ComponentModel.DataAnnotations;
using Typeform.Sdk.CSharp.Resources;

namespace Typeform.Sdk.CSharp.Enums
{
    public enum ShapeType
    {
        [Display(ResourceType = typeof(EnumText), Name = "Shape_Cat")]
        Cat,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Circle")]
        Circle,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Cloud")]
        Cloud,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Crown")]
        Crown,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Dog")]
        Dog,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Droplet")]
        Droplet,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Flag")]
        Flag,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Heart")]
        Heart,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Lightbulb")]
        Lightbulb,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Pencil")]
        Pencil,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Skull")]
        Skull,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Star")]
        Star,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Thunderbult")]
        Thunderbolt,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Tick")]
        Tick,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Trophy")]
        Trophy,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_Up")]
        Up,

        [Display(ResourceType = typeof(EnumText), Name = "Shape_User")]
        User
    }
}