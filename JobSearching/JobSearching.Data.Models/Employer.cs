using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CurrentAddress { get; set; }
        public string CompanyName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public ICollection<JobAd> JobAds { get; set; }
    }
}
