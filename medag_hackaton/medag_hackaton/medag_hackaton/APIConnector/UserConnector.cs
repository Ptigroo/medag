using medag_hackaton.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

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
        private UserConnector() : base("")
        {
        }

        public override int Convert(string json)
        {
            return int.Parse(json);
        }
    }
}
