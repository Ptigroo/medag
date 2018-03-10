using System;
using System.Collections.Generic;
using System.Text;

namespace medag_hackaton.Models.Zone
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Step> Steps { get; set; }
    }
}
