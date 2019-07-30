using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.ViewModels
{
    public class VolunteerProfileViewModel
    {

        public string Username { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int Age { get; set; }
        public string Contact { get; set; }

        public bool FailedLogInAttempt { get; set; } = false;
        public bool IsChangeable { get; set; }

        public IndexSingleAdViewModel SignedInAds { get; set; }

    }
}
