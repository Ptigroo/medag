using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace medag_hackaton.Interfaces
{
    public interface INavigation
    {
        Task Push(Page page);
        Task<Page> Pop();
        Task PushModal(Page page);
        Task<Page> PopModal();
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        void Subscribe<TObservable, TEventArgs>(TObservable obs, string topic, Action<TObservable, TEventArgs> callback);
        void Send(Object sender, string topic, object result);
        void Unsubscribe<TObservable, TEventArgs>(TObservable obs, string topic);
    }
}
