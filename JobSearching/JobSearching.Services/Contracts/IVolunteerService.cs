using JobSearching.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Services.Contracts
{
    public interface IVolunteerService
    {
        int CreateVolunteer(string userName, string password, string firstName, string lastName, int age, string volunteer);
        int LogInVolunteer(string userName, string password);
        bool ChangeVolunteer(string userName, string oldPassword, string newPassword, string firstName, string lastName, int age, string contact);
        VolunteerDetailViewModel GetVolunteer(int id);
        VolunteerProfileViewModel GetSignedVolunteer();
    }
}
