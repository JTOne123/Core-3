using System;
using System.Collections.Generic;
using System.Text;
using CreativeCoders.AspNetCore.Blazor.Components.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CreativeCoders.AspNetCore.Blazor.Components
{
    public partial class Button : BlazorBaseComponent
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter]
        public EventCallback<MouseEventArgs> OnClick { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> UnknownAttributes { get; set; }

        [Parameter]
        public ButtonElementType ButtonElementType { get; set; }

        public string TagName => 
            ButtonElementType switch
            {
                ButtonElementType.Button => "button",
                ButtonElementType.Link => "a",
                ButtonElementType.Div => "div",
                _ => "button"
            };
    }
}
