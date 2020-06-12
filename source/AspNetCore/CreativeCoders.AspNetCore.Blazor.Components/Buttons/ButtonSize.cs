using CreativeCoders.Core.Enums;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    [EnumStringValue(null)]
    public enum ButtonSize
    {
        Normal,
        [EnumStringValue("btn-sm")]
        Small,
        [EnumStringValue("btn-lg")]
        Large
    }
}