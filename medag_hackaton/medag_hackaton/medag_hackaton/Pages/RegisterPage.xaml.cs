using medag_hackaton.Interfaces;
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
<<<<<<< HEAD
            BindingContext = new LoginRegisterViewModel(new Navigations());
=======
>>>>>>> 92c85f2d1ee3e3b4169af887927f1887743d398d
            InitializeComponent ();
            BindingContext = new LoginRegisterViewModel(new Navigations());

        }
	}
}