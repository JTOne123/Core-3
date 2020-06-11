using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor
{
    public class ControlBase : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> CustomAttributes { get; set; }
    }
}