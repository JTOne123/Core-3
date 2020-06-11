using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;

namespace CreativeCoders.AspNetCore.Blazor
{
    public class CustomElement : ComponentBase
    {
        [Parameter]
        public string Tag { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> CustomAttributes { get; set; }

        [Parameter]
        public bool OnClickPreventDefault { get; set; }

        [Parameter]
        public bool OnClickStopPropagation { get; set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, Tag);

            builder.AddMultipleAttributes(1, CustomAttributes);
            builder.AddEventPreventDefaultAttribute(2, "onclick", OnClickPreventDefault);
            builder.AddEventStopPropagationAttribute(3, "onclick", OnClickStopPropagation);

            builder.AddContent(4, ChildContent);

            builder.CloseElement();
        }
    }
}