namespace CreativeCoders.AspNetCore.Blazor
{
    public class ClassControlBase : ControlBase
    {
        public ClassControlBase()
        {
            Classes = new ClassesAttribute();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            SetupClasses();
        }

        protected virtual void SetupClasses()
        {
            Classes.AddClass(() =>
                CustomAttributes != null && CustomAttributes.TryGetValue("class", out var className)
                    ? className.ToString()
                    : null);
        }

        public ClassesAttribute Classes { get; }
    }
}