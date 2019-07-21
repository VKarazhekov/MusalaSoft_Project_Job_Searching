using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.ViewModels
{
    public class EmployerFullViewModel
    {

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string CompanyName { get; set; }
        public string CompanyLocation { get; set; }

        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

    }
}
