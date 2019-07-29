using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class Volunteer
    {

        public Volunteer()
        {
            RegisteredOn = DateTime.UtcNow;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public int Age { get; set; }
        public string LastName { get; set; }
        public string ContactInformation { get; set; }
        public DateTime RegisteredOn { get; set; }
        public ICollection<JobVolunteer> JobAds { get; set; }
    }
}
