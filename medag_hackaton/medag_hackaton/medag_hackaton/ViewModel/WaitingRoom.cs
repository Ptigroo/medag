using medag_hackaton.Models.User;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace medag_hackaton.ViewModel
{
    class WaitingRoom : BaseViewModel
    {

        private ObservableCollection<UserModel> firstTeamList;

        public ObservableCollection<UserModel> FirstTeamList
        {
            get { return firstTeamList; }
            set
            {
                firstTeamList = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<UserModel> secondTeamList;

        public ObservableCollection<UserModel> SecondTeamList
        {
            get { return secondTeamList; }
            set { secondTeamList = value; }
        }

        public WaitingRoom(Interfaces.INavigation navigation) : base(navigation)
        {

        }

    }
}
