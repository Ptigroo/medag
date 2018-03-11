using medag_hackaton.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace medag_hackaton.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        private SynchronizationContext synchronizationContext = SynchronizationContext.Current;
        protected readonly INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            if(synchronizationContext != null)
            {
                synchronizationContext.Post((s) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)),null);
            }
            else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
            
        }

        public BaseViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
