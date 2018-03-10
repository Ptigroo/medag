using medag_hackaton.Models.User;
using medag_hackaton.Models.Zone;
using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Team
{
    public class EquipeModel
    {
        public List<UserModel> Players { get; set; }
        public string Nom { get; set; }
        public Position Position { get; set; }
        public ParcourModel Parcour { get; set; }

        public EquipeModel()
        {
            Players = new List<UserModel>();
        }
    }
}
