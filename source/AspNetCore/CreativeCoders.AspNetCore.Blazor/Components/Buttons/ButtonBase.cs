using CreativeCoders.AspNetCore.Blazor.Components.Base;
using CreativeCoders.Core.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class ButtonBase : ContainerControlBase
    {
        private const string ButtonClassPrefix = "btn-";

        private const string OutlinedButtonClassPrefix = "btn-outline-";

        protected override void SetupClasses()
        {
            base.SetupClasses();

            Classes
                .Add("btn")
                .Add(() => (IsOutlined ? OutlinedButtonClassPrefix : ButtonClassPrefix) + Kind.ToText())
                .Add(() => Size.ToText());
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