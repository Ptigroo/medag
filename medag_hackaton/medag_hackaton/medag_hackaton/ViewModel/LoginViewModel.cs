using medag_hackaton.APIConnector;
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
    class LoginViewModel : BaseViewModel
    {
        public LoginUser User { get; set; }
        public ICommand ValidateCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

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
        
        public LoginViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            User = new LoginUser();
            ValidateCommand = new Command(x => Login());
            RegisterCommand = new Command(async x => await navigation.Push(new RegisterPage()));

            ErrorMessage = "";
        }


        private async void Login()
        {
            if (User.IsValid)
            {
                UserModel UserModel = await UserConnector.Instance.Get(new UserModel() { Username = User.Username, Password = User.Password });
                if(UserModel != null)
                {
                    Application.Current.Properties.Add("user", UserModel);
<<<<<<< HEAD
                    ClientSignalR.Instance.Start();
=======
<<<<<<< HEAD
                    await Navigations.Push(new CityListPage());
                    return true;
=======
>>>>>>> 7b30a16b7990ac0c2d044a28ce529d9c0bcd3c61
                    ClientSignalR.Instance.Login(UserModel);
                    await navigation.Push(new HomePage(UserModel));
                   
>>>>>>> a9fe4e206c939da83f7142244aa40e5f74cc89be
                }
                else
                {
                    ErrorMessage = "Bad credentials";
                }
                
            }
            else
            {
                ErrorMessage = "Missing field(s)";
            }
        }
    }
}
