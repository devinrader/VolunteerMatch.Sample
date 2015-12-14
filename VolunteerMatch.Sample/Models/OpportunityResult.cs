using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerMatch.Sample.Models
{
    public class OpportunityResult
    {
        public int CurrentPage { get; set; }
        public int ResultsSize { get; set; }
        public string SortCriteria { get; set; }
        public IList<Opportunity> Opportunities { get; set; }
    }
}