using medag_hackaton.Models.User;
using medag_hackaton.Models.Zone;
using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Team
{
    public class Team
    {
        public Course Course { get; set; }
        public UserModel Teamleader { get; set; }
        public List<UserModel> TeamMembers { get; set; }
    }
}
