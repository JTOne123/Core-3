﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor.Components.Buttons
{
    public class CcDropDownBase<T> : ControlBase
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        [Parameter] public IReadOnlyCollection<T> DropDownItems { get; set; }

        [Parameter] public RenderFragment ButtonTemplate { get; set; }

        [Parameter] public RenderFragment<T> DropDownItemTemplate { get; set; }
    }
}