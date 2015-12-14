using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerMatch.Sample.Models
{
    public class Availability
    {
        public string EndDate { get; set; }
        public string EndTime { get; set; }
        public bool Ongoing { get; set; }
        public bool SingleDayOpportunity { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
    }
}