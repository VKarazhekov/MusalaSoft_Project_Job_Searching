using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class Volunteer
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public int age { get; set; }
        public string lastName { get; set; }
        public string contactInformation { get; set; }
        public ICollection<JobVolunteer> JobAds { get; set; }
    }
}
