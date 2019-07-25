using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class JobVolunteer
    {
        public int JobAdId { get; set; }
        public JobAd JobAd { get; set; }
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
    }
}
