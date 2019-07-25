using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Data.Models
{
    public class Employer
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int age { get; set; }
        public string currentAddress { get; set; }
        public string companyName { get; set; }
        public string contactEmail { get; set; }
        public string contactPhone { get; set; }
    }
}
