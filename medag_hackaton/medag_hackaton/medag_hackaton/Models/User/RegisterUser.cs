using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.User
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Email { get; set; }

        
        public string Password { get; set; }        
        public string Password2 { get; set; }

        public bool IsPassValid { get{ return Password == Password2; } }


    }
}
