using System;
using System.Collections.Generic;
using System.Linq;
using CreativeCoders.Core;
using JetBrains.Annotations;

namespace CreativeCoders.AspNetCore.Blazor
{
    [PublicAPI]
    public class AttributeBuilder
    {
        private bool _needsRebuild;

        private string _text;

        private readonly string _separatorForJoin;

        private readonly List<Func<string>> _items;

        public AttributeBuilder(string separatorForJoin, string separatorForSplit)
        {
            _separatorForJoin = separatorForJoin;
            _items = new List<Func<string>>();

            _needsRebuild = true;
        }

        public AttributeBuilder Add(string attributePart)
        {
            return Add(() => attributePart);
        }

        public AttributeBuilder Add(Func<string> attributePart)
        {
            _items.Add(attributePart);

            return this;
        }

        public AttributeBuilder AddIf(Func<bool> condition, string attributePart)
        {
            return Add(() => condition() ? attributePart : null);
        }

        public AttributeBuilder AddIf(Func<bool> condition, Func<string> attributePart)
        {
            return Add(() => condition() ? attributePart() : null);
        }

        public string Build()
        {
            var items =
                _items
                    .Select(x => x())
                    .WhereNotNull()
                    .SelectMany(x => x.Split(_separatorForJoin, StringSplitOptions.RemoveEmptyEntries))
                    .Distinct()
                    .ToArray();

            return items.Any() ? string.Join(_separatorForJoin, items) : null;
        }

        public void NeedsRebuild()
        {
            _needsRebuild = true;
        }

        public override string ToString()
        {
            if (_needsRebuild)
            {
                _text = Build();
            }

            return _text;
        }
    }
}