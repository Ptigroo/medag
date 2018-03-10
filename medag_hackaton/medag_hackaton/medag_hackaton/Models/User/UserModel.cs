using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public bool Chef { get; set; }
    }
}