using medag_hackaton.Interfaces;
using medag_hackaton.Models.Team;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace medag_hackaton.ViewModel
{
    class HomeViewModel : BaseViewModel
    {
        public ICommand JoinTeam { get; set; }
        public ICommand CreateGame { get; set; }
        public string firstTeam;
        public string FirstTeam {
            get
            {
                return firstTeam;
            }
            set
            {
                firstTeam = value;
                OnPropertyChanged();
                (CreateGame as Command).ChangeCanExecute();
            }
        }
        public string secondTeam;
        public string SecondTeam {
            get
            {
                return secondTeam;
            }
            set
            {
                secondTeam = value;
                OnPropertyChanged();
                (CreateGame as Command).ChangeCanExecute();
            }
        }
        public EquipeModel TeamSelected { get; set; }
        public string password;
        public string Password {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged();
                (CreateGame as Command).ChangeCanExecute();
            }
        }
        public string roomName;
        public string RoomName {
            get
            {
                return roomName;
            }
            set
            {
                roomName = value;
                OnPropertyChanged();
                (CreateGame as Command).ChangeCanExecute();
            }
            }
        public ObservableCollection<EquipeModel> roomsBinding;
        public ObservableCollection<EquipeModel> RoomsBinding
        {
            get
            {
                return roomsBinding;
            }
            set
            {
                roomsBinding = value;
                OnPropertyChanged();
            }
        }
        public HomeViewModel(Interfaces.INavigation navigation) : base(navigation)
        {
            JoinTeam = new Command((x) => Join(), x=> (TeamSelected != null));
            CreateGame = new Command((x) => Create(), x => (FirstTeam != null && SecondTeam != null && RoomName != null && Password != null));
            ClientSignalR.Instance.ListenRooms(RoomsBinding);
        }
        public void Create()
        {
            ClientSignalR.Instance.Start();
            ClientSignalR.Instance.CreateRoom(roomName, password, firstTeam, secondTeam);

        }
        public void Join()
        {

        }

    }
}
