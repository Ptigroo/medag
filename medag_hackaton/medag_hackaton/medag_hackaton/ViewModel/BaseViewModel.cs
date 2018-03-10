using medag_hackaton.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace medag_hackaton.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected readonly INavigation navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public BaseViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }
    }
}
