﻿using medag_hackaton.Interfaces;
using medag_hackaton.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace medag_hackaton.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
            InitializeComponent ();
            BindingContext = new LoginRegisterViewModel(new Navigations());

        }
	}
}