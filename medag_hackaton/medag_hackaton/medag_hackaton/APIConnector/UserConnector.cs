using medag_hackaton.Configs;
using medag_hackaton.Models.User;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace medag_hackaton.APIConnector
{
    public class UserConnector : BaseApiConnector<int, UserModel>
    {
        private static UserConnector instance;
        public static UserConnector Instance
        {
            get
            {
                return instance ?? (instance = new UserConnector());
            }
        }
        private UserConnector() : base(ConnectionConfig.UserURL)
        {
        }

        public override int Convert(string json)
        {
            return int.Parse(json);
        }

        public async override Task<UserModel> Get(UserModel user)
        {
            using (HttpClient client = new HttpClient())
            {
                Uri = new Uri($"{Url}?username={user.Username}&password={user.Password}");
                HttpResponseMessage message = await client.GetAsync(Uri);
                return JsonConvert.DeserializeObject<UserModel>(await message.Content.ReadAsStringAsync());
            }
        }



        //public async Task<int> Login(LoginUser user)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        //Uri = new Uri($"{Url}?Username={user.Username}&Password={user.Password}");
        //        //HttpResponseMessage message = await client.GetAsync(Uri);
        //        //return JsonConvert.DeserializeObject<int>(await message.Content.ReadAsStringAsync());


        //    }
        //}
        //public async Task<int> Register(RegisterUser user)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        Uri = new Uri($"{Url}");
        //        HttpContent content = new StringContent(JsonConvert.SerializeObject(user));
        //        HttpResponseMessage message = await client.PostAsync(Uri,content);
        //        return JsonConvert.DeserializeObject<int>(await message.Content.ReadAsStringAsync());
        //    }
        //}
    }
}
