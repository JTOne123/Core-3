using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor
{
    public class ContainerControlBase : ControlBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}