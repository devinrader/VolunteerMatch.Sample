using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VolunteerMatch.Sample.Models
{
    public class Opportunity
    {
        public Availability Availability { get; set; }
        public int[] CategoryIds { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public string vmUrl { get; set; }
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public Location Location { get; set; }
        public Organization ParentOrg { get; set; }
        public string PlainTextDescription { get; set; }

        public string Tags { get; set; }
        public bool Virtual { get; set; }
    }



   



}