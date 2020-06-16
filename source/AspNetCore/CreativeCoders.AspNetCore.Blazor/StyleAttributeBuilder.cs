using System;
using JetBrains.Annotations;

namespace CreativeCoders.AspNetCore.Blazor
{
    [PublicAPI]
    public class StyleAttributeBuilder : AttributeBuilder
    {
        public StyleAttributeBuilder() : base(" ", ";") { }

        public StyleAttributeBuilder AddProperty(string propertyName, string value)
        {
            Add($"{propertyName}: {value};");

            return this;
        }

        public StyleAttributeBuilder AddProperty(Func<string> propertyName, Func<string> value)
        {
            Add(() => $"{propertyName()}: {value()};");

            return this;
        }
    }
}