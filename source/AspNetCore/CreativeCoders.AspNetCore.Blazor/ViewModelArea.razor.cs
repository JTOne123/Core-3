using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CreativeCoders.AspNetCore.Blazor.Components;
using CreativeCoders.AspNetCore.Blazor.Components.Base;
using CreativeCoders.Core;
using CreativeCoders.Core.Threading;
using Microsoft.AspNetCore.Components;

namespace CreativeCoders.AspNetCore.Blazor
{
    public partial class ViewModelArea<TViewModel> : ContainerControlBase, IDisposable
        where TViewModel : class, INotifyPropertyChanged
    {
        private IList<string> _observeProperties = new List<string>();

        private IList<string> _excludeProperties = new List<string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (ViewModel == null)
            {
                return;
            }

            ViewModel.PropertyChanged += ViewModelOnPropertyChanged;
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            _observeProperties = new List<string>(
                ObserveProperties?.Split(new[] {' ', ',', ';'}, StringSplitOptions.RemoveEmptyEntries)
                    .WhereNotNull() ?? new string[0]);

            _excludeProperties = new List<string>(
                ExcludeProperties?.Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .WhereNotNull() ?? new string[0]);
        }

        private void ViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_observeProperties.Count > 0 && !_observeProperties.Contains(e.PropertyName))
            {
                return;
            }

            if (_excludeProperties.Count > 0 && _excludeProperties.Contains(e.PropertyName))
            {
                return;
            }

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

        [Parameter]
        public string ObserveProperties { get; set; }

        [Parameter]
        public string ExcludeProperties { get; set; }
    }
}