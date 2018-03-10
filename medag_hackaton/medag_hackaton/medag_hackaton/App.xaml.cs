using medag_hackaton.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace medag_hackaton
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

<<<<<<< HEAD
			MainPage = new NavigationPage( new LoginPage() );
=======
			MainPage = new NavigationPage( new HomePage());
>>>>>>> 3b7d7b132fb0e7dde80f0e556ec346f58a546d3b
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
