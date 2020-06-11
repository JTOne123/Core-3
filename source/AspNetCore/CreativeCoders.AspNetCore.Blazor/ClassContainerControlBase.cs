using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor
{
    public class ClassContainerControlBase : ClassControlBase
    {
        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}