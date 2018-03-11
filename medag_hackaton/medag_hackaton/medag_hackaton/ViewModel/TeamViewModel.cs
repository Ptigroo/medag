using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using medag_hackaton.Interfaces;
using medag_hackaton.Models.Team;
using medag_hackaton.Models.User;
using Xamarin.Forms;

namespace medag_hackaton.ViewModel
{
    class TeamViewModel : BaseViewModel
    {
        public ICommand JoinTeamOneCommand { get; set; }
        public ICommand JoinTeamTwoCommand { get; set; }

        public RoomModel Room { get; set; }
        private UserModel user;

        private bool isInTheTeam;
        public bool IsInTheTeam
        {
            get
            {
                return isInTheTeam;
            }
            set
            {
                isInTheTeam = value;
                OnPropertyChanged();
                (JoinTeamOneCommand as Command).ChangeCanExecute();
                (JoinTeamTwoCommand as Command).ChangeCanExecute();
            }
        }

        private IEnumerable<UserModel> playersTeamOne;
        public IEnumerable<UserModel> PlayersTeamOne
        {
            get
            {
                return playersTeamOne;
            }
            set
            {
                playersTeamOne = value;
                OnPropertyChanged();
            }
        }

        private IEnumerable<UserModel> playersTeamTwo;
        public IEnumerable<UserModel> PlayersTeamTwo
        {
            get
            {
                return playersTeamTwo;
            }
            set
            {
                playersTeamTwo = value;
                OnPropertyChanged();
            }
        }

        public TeamViewModel(Interfaces.INavigation navigation,RoomModel room,UserModel user) : base(navigation)
        {
            ClientSignalR.Instance.SetPlayersInTheRoomEvent += SetPlayersInTheRooms;
            ClientSignalR.Instance.ListenTeamPlayers();
            this.user = user;
            this.Room = room;

            PlayersTeamOne = room.Equipe1.Players;
            PlayersTeamTwo = room.Equipe2.Players;

            JoinTeamOneCommand = new Command(x=>JoinTeamOne(),x=>!IsInTheTeam);
            JoinTeamTwoCommand = new Command(x=>JoinTeamTwo(),x=>!IsInTheTeam);
        }

        public async void JoinTeamOne()
        {
            IsInTheTeam = true;
            await ClientSignalR.Instance.JoinTeam(Room.Equipe1.Nom, user);
        }

        public async void JoinTeamTwo()
        {
            IsInTheTeam = true;
            await ClientSignalR.Instance.JoinTeam(Room.Equipe2.Nom, user);
        }

        public void SetPlayersInTheRooms(RoomModel Room)
        {
            PlayersTeamOne = Room.Equipe1.Players;
            playersTeamTwo = Room.Equipe2.Players;
        }

    }
}
