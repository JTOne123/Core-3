using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class CcCustomButtonBase : CcButtonBase
    {
        [Parameter]
        public ButtonElementType ElementType { get; set; }
    }
}