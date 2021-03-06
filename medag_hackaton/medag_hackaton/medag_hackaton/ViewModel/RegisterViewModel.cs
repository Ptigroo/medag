﻿using medag_hackaton.APIConnector;
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
        private bool _IsRegisterButtonEnabled;

        public bool IsRegisterButtonEnabled
        {
            get { return _IsRegisterButtonEnabled; }
            set { _IsRegisterButtonEnabled = value; OnPropertyChanged(); }
        }

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
            ValidateCommand = new Command(async () => await Register());
            ErrorMessage = "";
        }


        private async Task<bool> Register()
        {
            IsRegisterButtonEnabled = false;

            if (User.IsValid)
            {
                UserModel userModel = new UserModel() { Mail = User.Mail, Username = User.Username , Password= User.Password};
                userModel.Id = await UserConnector.Instance.Insert(userModel);
                if (userModel.Id != 0)
                {
                    Application.Current.Properties.Add("user", userModel);
                    IsRegisterButtonEnabled = true;
                    await navigation.Push(new CityListPage());

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
            IsRegisterButtonEnabled = true;
            return false;
        } 
    }
}
