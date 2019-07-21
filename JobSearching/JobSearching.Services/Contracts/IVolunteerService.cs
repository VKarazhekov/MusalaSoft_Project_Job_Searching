using JobSearching.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Services.Contracts
{
    public interface IVolunteerService
    {
        int CreateVolunteer(string userName, string password, string firstName, string lastName, int age, string volunteer);
        void LogInVolunteer(string userName, string password);
        VolunteerDetailViewModel GetVolunteer(int id);
    }
}
