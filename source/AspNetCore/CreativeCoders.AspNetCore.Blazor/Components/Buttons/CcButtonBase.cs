using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class CcButtonBase : ButtonBase
    {
        [Parameter]
        public ButtonType ButtonType { get; set; }
    }
}