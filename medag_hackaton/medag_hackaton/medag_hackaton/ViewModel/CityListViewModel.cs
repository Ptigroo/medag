using medag_hackaton.Interfaces;
using medag_hackaton.Models.User;
using medag_hackaton.Models.Zone;
using medag_hackaton.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using forms = Xamarin.Forms;

namespace medag_hackaton.ViewModel
{
    class CityListViewModel : BaseViewModel
    {
        private ObservableCollection<City> _Cities;

        public ObservableCollection<City> Cities
        {
            get { return _Cities; }
            set
            {
                _Cities = value;
                OnPropertyChanged();
            }
        }
        private City citySelected;

        public City CitySelected
        {
            get { return citySelected; }
            set {
                OnPropertyChanged();
                citySelected = value;
                CitySelectedF();

            }
        }

        public INavigation Navigation { get; set; }
        public CityListViewModel(Interfaces.INavigation nav) : base(nav)
        {
            Cities = new ObservableCollection<City>();
            Cities.Add(new City() { Id=1,Name="Mons" });
            Navigation = nav;
        }


        public async void CitySelectedF()
        {
<<<<<<< HEAD
            if (CitySelected != null)
            {
                var dataItem = citySelected;
                forms.Application.Current.Properties.Add("city", dataItem);
                
                citySelected = null;
                await Navigation.Push(new HomePage((UserModel)forms.Application.Current.Properties["user"]));
                //await Navigation.Push(new HomePage(new UserModel() { Id = 1, Username = "test", Mail = "test@test.com" }));
            }
            
=======
            var dataItem = citySelected;
            forms.Application.Current.Properties.Add("city", dataItem);
            //await Navigation.Push(new HomePage());
>>>>>>> b357bf510319758d62fe1e077256a59bdb906cb9
        }

    }
}
