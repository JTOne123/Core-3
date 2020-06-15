using System;

namespace CreativeCoders.AspNetCore.Blazor
{
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