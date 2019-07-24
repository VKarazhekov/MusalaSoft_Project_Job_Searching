using System;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Text;
using JobSearching.Data;
using JobSearching.ViewModels;

namespace JobSearching.Services
{
    public class VolunteerService : IVolunteerService
    {

        /*
        private JobSearchingDbContext context;
        public VolunteerService(JobSearchingDbContext context)
        {
            this.context = context;
        }
        */

        public int CreateVolunteer(string userName, string password, string firstName, string lastName, int age, string volunteer)
        {
            throw new NotImplementedException("Impl. CreateVolunteer()");
        }

        public void LogInVolunteer(string userName, string password)
        {
            // При успешен logIn актуализирай CurrentSigned.VolunteerId
            throw new NotImplementedException("Impl. LogIn()");
        }

        public void ChangeVolunteer(string userName, string oldPassword, string newPassword, string firstName, string lastName, int age, string contact)
        {
            throw new NotImplementedException("Impl. ChangeVolunteer()");
        }

        public VolunteerDetailViewModel GetVolunteer(int id)
        {
            // виж VolnteerController -> Detail();
            throw new NotImplementedException("Impl. GetVolunteer(id)");
        }

        public VolunteerProfileViewModel GetSignedVolunteer()
        {
            throw new NotImplementedException("Impl. GetSignedVolunteer()");
        }

        
    }
}
