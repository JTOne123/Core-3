using CreativeCoders.Core.Enums;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    [EnumStringValue("btn-primary")]
    public enum ButtonKind
    {
        [EnumStringValue("btn-primary")]
        Primary,
        [EnumStringValue("btn-secondary")]
        Secondary,
        [EnumStringValue("btn-success")]
        Success,
        [EnumStringValue("btn-danger")]
        Danger,
        [EnumStringValue("btn-warning")]
        Warning,
        [EnumStringValue("btn-warning")]
        Info,
        [EnumStringValue("btn-light")]
        Light,
        [EnumStringValue("btn-dark")]
        Dark,
        [EnumStringValue("btn-link")]
        Link
    }
}