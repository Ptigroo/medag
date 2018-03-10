using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace medag_hackaton.Interfaces
{
    class Navigations : INavigation
    {
        public Navigations()
        {
            //navigationPage = navigation;
        }
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        public async Task<Page> Pop()
        {
            return await App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task<Page> PopModal()
        {
            return await App.Current.MainPage.Navigation.PopModalAsync();
        }

        public async Task Push(Page page)
        {
            await App.Current.MainPage.Navigation.PushAsync(page);
        }

        public async Task PushModal(Page page)
        {
            await App.Current.MainPage.Navigation.PushModalAsync(page);
        }

        public void Send(object sender, string topic, object result)
        {

        }

        public void Subscribe<TObservable, TEventArgs>(TObservable obs, string topic, Action<TObservable, TEventArgs> callback)
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<TObservable, TEventArgs>(TObservable obs, string topic)
        {
            throw new NotImplementedException();
        }
    }
}
