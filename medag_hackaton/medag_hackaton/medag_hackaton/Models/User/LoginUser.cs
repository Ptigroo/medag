using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.User
{
    public class LoginUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public bool IsValid
        {
            get
            {
                return Email != null
                    && Username != null
                    && Password != null
                    && Email != ""
                    && Username != ""
                    && Password != "";
            }
        }
    }
}
