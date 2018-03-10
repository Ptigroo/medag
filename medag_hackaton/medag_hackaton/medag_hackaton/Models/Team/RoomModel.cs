using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Team
{
    public class RoomModel
    {
        public string Name { get; set; }
        public EquipeModel Equipe1 { get; set; }
        public EquipeModel Equipe2 { get; set; }
        public string Password { get; set; }
    }
}
