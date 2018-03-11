using medag_hackaton.Models.Team;
using medag_hackaton.Models.User;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace medag_hackaton
{
    class ClientSignalR
    {
        private static ClientSignalR instance;
        public static ClientSignalR Instance
        {
            get
            {
                return instance ?? (instance = new ClientSignalR());
            }
            set
            {
                instance = value;
            }
        }


        public IEnumerable<UserModel> Users { get; set; }
        public IHubProxy Hub { get; set; }
        private HubConnection conn;
        public RoomModel RoomCo { get; set; }

        public event Action<IEnumerable<RoomModel>> SetRooms;
        public event Action<RoomModel> SetPlayersInTheRoomEvent;

        private ClientSignalR()
        {
            conn = new HubConnection("http://www.walfhand.be");
            Hub = conn.CreateHubProxy("GameHub");
            Start();
        }

        public void Start()
        {
            conn.Start().Wait();
        }

        public void StartGame()
        {
            Hub.On<string>("Error", x => { });
            Hub.On<object>("BroadcastPlayerRoom", x => { Users = GetUser(x); });
        }

        public async void Login(UserModel user)
        {
            await Hub.Invoke<bool>("Login", (user.Id));
        }

        public async Task JoinTeam(string teamName, UserModel user)
        {
            await Hub.Invoke("JoinTeam", teamName, user.Id);
        }

        public void ListenTeamPlayers()
        {
            Hub.On<object>("BroadCastPlayerRoom", x => { ConvertPlayersTeam(x); });
        }

        public void ConvertPlayersTeam(object o)
        {
            string json = o.ToString();
            RoomModel room = JsonConvert.DeserializeObject<RoomModel>(json);
            SetPlayersInTheRoomEvent?.Invoke(room);
        }

        public async Task<IEnumerable<RoomModel>> GetRooms()
        {
            return await Hub.Invoke<IEnumerable<RoomModel>>("GetRooms");
        }
        public void ListenRoom()
        {
            Hub.On<string>("Error", x => { });
            Hub.On<object>("BroadcastPlayerRoom", x => { RoomCo = ConvertRoom(x); });
        }

        public void ListenRooms()
        {
            Hub.On<object>("BroadcastPlayerRooms", x => { ConvertRooms(x); });
        }

        public void ConvertRooms(object o)
        {
            string json = o.ToString();
            IEnumerable<RoomModel> rooms = JsonConvert.DeserializeObject<IEnumerable<RoomModel>>(json);
            SetRooms?.Invoke(rooms);
        }

        public RoomModel ConvertRoom(object o)
        {
            string json = o.ToString();
            return JsonConvert.DeserializeObject<RoomModel>(json);
        }
        public IEnumerable<UserModel> GetUser(object o)
        {
            string json = o.ToString();
            return JsonConvert.DeserializeObject<IEnumerable<UserModel>>(json);
        }
        public void CreateRoom(string nameRoom, string password, string nameTeamOne, string nameTeamTwo)
        {
            EquipeModel team1 = new EquipeModel()
            {
                Nom = nameTeamOne
            };
            EquipeModel team2 = new EquipeModel()
            {
                Nom = nameTeamTwo
            };
            RoomCo = new RoomModel()
            {
                Name = nameRoom,
                Password = password,
                Equipe1 = team1,
                Equipe2 = team2
            };
            Hub.Invoke("CreateRoom", RoomCo);
        }
        public async void Disconect(string username)
        {
            await Hub.Invoke("Disconect", username);
        }
 
    }
}
