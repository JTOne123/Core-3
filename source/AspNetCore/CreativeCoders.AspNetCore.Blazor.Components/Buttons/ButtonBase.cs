using CreativeCoders.Core.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class ButtonBase : ClassContainerControlBase
    {
        private const string ButtonClassPrefix = "btn-";

        private const string OutlinedButtonClassPrefix = "btn-outline-";

        protected override void SetupClasses()
        {
            base.SetupClasses();

            Classes
                .AddClass("btn")
                .AddClass(() => (IsOutlined ? OutlinedButtonClassPrefix : ButtonClassPrefix) + Kind.ToText())
                .AddClass(() => Size.ToText());
        }

        [Parameter]
        public EventCallback<MouseEventArgs> Clicked { get; set; }

        [Parameter]
        public ButtonKind Kind { get; set; }

        [Parameter] 
        public bool IsOutlined { get; set; }

        [Parameter]
        public ButtonSize Size { get; set; }
    }
}