using medag_hackaton.Interfaces;
using medag_hackaton.Models.Team;
using medag_hackaton.Models.User;
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
	public partial class TeamPage : ContentPage
	{
		public TeamPage (UserModel user,RoomModel room)
		{
			InitializeComponent ();
            BindingContext = new TeamViewModel(new Navigations(), room, user);
		}
	}
}