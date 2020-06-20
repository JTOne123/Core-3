using CreativeCoders.Core.Enums;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    [EnumStringValue("button")]
    public enum ButtonElementType
    {
        Button,
        [EnumStringValue("a")]
        Link,
        [EnumStringValue("div")]
        Div
    }
}