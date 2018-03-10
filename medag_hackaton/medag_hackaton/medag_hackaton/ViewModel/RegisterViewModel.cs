using medag_hackaton.APIConnector;
using medag_hackaton.Interfaces;
using medag_hackaton.Models.User;
using medag_hackaton.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace medag_hackaton.ViewModel
{
    class RegisterViewModel : BaseViewModel
    {
        public Interfaces.INavigation Navigations { get; }
        public RegisterUser User { get; set; }
        public ICommand ValidateCommand { get; set; }
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get
            {
                return _ErrorMessage;
            }
            set
            {
                _ErrorMessage = value;
                OnPropertyChanged();
            }
        }
        public RegisterViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            User = new RegisterUser();
            this.Navigations = navigation;
            ValidateCommand = new Command(async () => await Register());
            ErrorMessage = "";
        }


        private async Task<bool> Register()
        {

            if (User.IsValid)
            {
                UserModel UserModel = await UserConnector.Instance.Register(User);
                if (UserModel != null)
                {
                    await Navigations.Push(new HomePage());
                    return true;
                }
                else
                {
                    ErrorMessage = "Bad Entry(ies)";
                }
                
            }
            else
            {
                ErrorMessage = "Missing field(s)";
            }
            return false;
        } 
    }
}
