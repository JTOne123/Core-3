namespace CreativeCoders.AspNetCore.Blazor
{
    public class ClassControlBase : ControlBase
    {
        public ClassControlBase()
        {
            Classes = new ClassesAttribute();

            Classes.AddClass(() =>
            {
                if (CustomAttributes == null)
                {
                    return null;
                }

                if (CustomAttributes.TryGetValue("class", out var className))
                {
                    return className.ToString();
                }

                return null;
            });
        }

        public ClassesAttribute Classes { get; }
    }
}