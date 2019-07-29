using System;
using JobSearching.Services.Contracts;
using JobSearching.Services;
using System.Collections.Generic;
using System.Text;
using JobSearching.Data;
using JobSearching.ViewModels;
using JobSearching.Data.Models;

namespace JobSearching.Services
{
    public class VolunteerService : IVolunteerService
    {

        
        private JobSearchingDbContext context;
        public VolunteerService(JobSearchingDbContext context)
        {
            this.context = context;
        }
        
        private void Validate()
        {
            throw new NotImplementedException();
            /// Throw new ArgumentException("Explain what is the problem")
        }

        public int CreateVolunteer(string userName, string password, string firstName, string lastName, int age, string contact)
        {

            //// Validate();
            //// MUST HAVE VALIDATION
             
            var newVolunter = new Volunteer()
            {
                Username = userName,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                ContactInformation = contact
            };
            
            context.Volunteers.Add(newVolunter);

            context.SaveChanges();

            context.Entry(newVolunter).GetDatabaseValues();
            //secures that object newVolunteer will have properly Id

            return newVolunter.Id;

        }
        

        public int LogInVolunteer(string userName, string password)
        {
            // При успешен logIn актуализирай CurrentSigned.VolunteerId
            throw new NotImplementedException("Impl. LogIn()");
        }


        public bool ChangeVolunteer(string userName, string oldPassword, string newPassword, string firstName, string lastName, int age, string contact)
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
