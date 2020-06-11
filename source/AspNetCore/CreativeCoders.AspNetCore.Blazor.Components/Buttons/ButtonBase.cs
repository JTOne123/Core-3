using CreativeCoders.Core.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class ButtonBase : ClassContainerControlBase
    {
        public ButtonBase()
        {
            Classes
                .AddClass("btn")
                .AddClass(() => Kind.ToText());
        }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter]
        public ButtonElementType ButtonElementType { get; set; }

        [Parameter]
        public ButtonType ButtonType { get; set; }

        [Parameter]
        public ButtonKind Kind { get; set; }

        //public string ClassName => Classes.Build();
    }
}