using CreativeCoders.Core.Enums;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    [EnumStringValue("primary")]
    public enum ButtonKind
    {
        [EnumStringValue("primary")]
        Primary,
        [EnumStringValue("secondary")]
        Secondary,
        [EnumStringValue("success")]
        Success,
        [EnumStringValue("danger")]
        Danger,
        [EnumStringValue("warning")]
        Warning,
        [EnumStringValue("warning")]
        Info,
        [EnumStringValue("light")]
        Light,
        [EnumStringValue("dark")]
        Dark,
        [EnumStringValue("link")]
        Link
    }
}