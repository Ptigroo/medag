using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.User
{
    public class RegisterUser
    {
        public string Username { get; set; }
        public string Mail { get; set; }
        
        public string Password { get; set; }        
        public string Password2 { get; set; }

        public bool IsValid { get
            {
                return Mail != null
                    && Username != null
                    && Password != null                    
                    && Mail != ""
                    && Username != ""
                    && Password != ""
                    && Password == Password2;
            }
        }


    }
}
