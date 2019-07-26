using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class JobAd
    {
        public int Id { get; set; }
        public string PositionName {get; set;}
        public int EmployerId { get; set; }
        public string Description { get; set; }
        public ICollection<JobVolunteer> Volunteers { get; set; }
        public Employer Employer { get; set; }
    }
}
