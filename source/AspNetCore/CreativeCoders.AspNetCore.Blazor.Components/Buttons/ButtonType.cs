using CreativeCoders.Core.Enums;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    [EnumStringValue(null)]
    public enum ButtonType
    {
        Button,
        [EnumStringValue("submit")]
        Submit,
        [EnumStringValue("reset")]
        Reset
    }
}