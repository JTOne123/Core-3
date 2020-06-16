using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor.Components
{
    public class ItemsControlBase<TItem> : ControlBase
    {
        [Parameter]
        public RenderFragment<TItem> ItemTemplate { get; set; }

        [Parameter]
        public IReadOnlyCollection<TItem> Items { get; set; }
    }
}