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
			MainPage = new NavigationPage( new LoginPage());
=======
			MainPage = new NavigationPage( new MapPage());
>>>>>>> 3a7350bb5910260f3f70e6396a682b56949dad8e
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
