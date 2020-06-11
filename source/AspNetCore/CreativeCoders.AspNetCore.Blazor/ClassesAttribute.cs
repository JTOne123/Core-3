using System;
using System.Collections.Generic;
using System.Linq;
using CreativeCoders.Core;

namespace CreativeCoders.AspNetCore.Blazor
{
    public class ClassesAttribute
    {
        private readonly List<Func<string>> _items;

        public ClassesAttribute()
        {
            _items = new List<Func<string>>();
        }

        public ClassesAttribute AddClass(string className)
        {
            return AddClass(() => className);
        }

        public ClassesAttribute AddClass(Func<string> text)
        {
            _items.Add(text);

            return this;
        }

        public ClassesAttribute AddClassIf(Func<bool> condition, string className)
        {
            _items.Add(() => condition() ? className : null);

            return this;
        }

        public ClassesAttribute AddFromAttributes(IDictionary<string, object> attributes)
        {
            if (attributes == null)
            {
                return this;
            }

            if (attributes.TryGetValue("class", out var className))
            {
                AddClass(className.ToString());
            }

            return this;
        }

        public string Build()
        {
            var items =
                _items
                    .Select(x => x())
                    .WhereNotNull();

            var classNames = 
                items
                    .SelectMany(x => x.Split(" ", StringSplitOptions.RemoveEmptyEntries))
                    .Distinct();

            return string.Join(" ", classNames);
        }
    }
}