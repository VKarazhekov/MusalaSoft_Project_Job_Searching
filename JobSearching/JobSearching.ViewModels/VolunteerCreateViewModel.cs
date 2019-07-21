using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.ViewModels
{
    public class VolunteerCreateViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Contact { get; set; }
    }
}
