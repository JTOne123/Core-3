using System;
using System.ComponentModel;
using CreativeCoders.Core.Threading;
using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor
{
    public partial class ViewModelContainer<TViewModel> : ContainerControlBase, IDisposable
        where TViewModel : class, INotifyPropertyChanged
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (ViewModel == null)
            {
                return;
            }

            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged).FireAndForgetAsync(ex => {});
        }

        public void Dispose()
        {
            if (ViewModel == null)
            {
                return;
            }

            ViewModel.PropertyChanged -= ViewModelOnPropertyChanged;
        }

        [Parameter]
        public TViewModel ViewModel { get; set; }
    }
}