using medag_hackaton.Interfaces;
using medag_hackaton.ViewModel;
using Plugin.Geolocator;
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
	public partial class MapPage : ContentPage
	{
        
        public MapPage ()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent ();
            BindingContext = new MapPageViewModel(new Navigations());
            
        }
        
	}
}