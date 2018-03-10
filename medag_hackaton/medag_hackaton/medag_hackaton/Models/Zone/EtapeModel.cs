using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Zone
{
    public class EtapeModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public Position Position { get; set; }
        public string PhotoPath { get; set; }
        public string Question { get; set; }
    }
}
