using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Zone
{
    public class Step
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Position Position { get; set; }
        public string Picture { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
    }
}
