using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class JobAd
    {
        public int id { get; set; }
        public string positionName {get; set;}
        public string employerId { get; set; }
        public string description { get; set; }
        public ICollection<JobVolunteer> Volunteers { get; set; }
    }
}
