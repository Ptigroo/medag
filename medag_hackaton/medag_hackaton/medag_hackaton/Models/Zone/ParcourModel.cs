using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Zone
{
    public class ParcourModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public List<EtapeModel> Steps { get; set; }
    }
}
