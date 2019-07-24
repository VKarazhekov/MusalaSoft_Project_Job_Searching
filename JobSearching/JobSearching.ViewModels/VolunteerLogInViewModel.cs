using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.ViewModels
{
    public class VolunteerLogInViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool FailedLogInAttempt { get; set; } = false;

    }
}
