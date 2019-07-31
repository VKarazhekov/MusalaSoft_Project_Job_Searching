using System;
using System.Linq;
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
        
        private void Validate(string userName, string password, string firstName, string lastName, int age, string contact)
        {
            if(userName.Length < 6 || userName.Length > 20)
            {
                throw new ArgumentException("Please enter an username that has a length between 6 and 20 symbols.");
            }
            if(char.IsDigit(userName[0]))
            {
                throw new ArgumentException("Username cannot start with a digit. Please enter a different username.");
            }
            if(context.Volunteers.FirstOrDefault(v => v.Username == userName) != null)
            {
                throw new ArgumentException("The username entered is already taken. Please enter a different username.");
            }
            if (password.Length < 6 || password.Length > 20)
            {
                throw new ArgumentException("Please enter a password that has a length between 6 and 20 symbols.");
            }
            if (!firstName.All(char.IsLetter))
            {
                throw new ArgumentException("Please enter a first name that contains only letters.");
            }
            if (firstName.Length == 1 || firstName.Length > 15)
            {
                throw new ArgumentException("Please enter a first name with length between 2 and 15 letters.");
            }
            if (!char.IsUpper(firstName[0]) || !firstName.Skip(1).All(char.IsLower))
            {
                throw new ArgumentException("Please enter a first name that starts with an uppercase letter and follows with lowercase letters.");
            }
            if (!lastName.All(char.IsLetter))
            {
                throw new ArgumentException("Please enter a last name that contains only letters.");
            }
            if (lastName.Length == 1 || lastName.Length > 15)
            {
                throw new ArgumentException("Please enter a last name with length between 2 and 15 letters.");
            }
            if (!char.IsUpper(lastName[0]) || !lastName.Skip(1).All(char.IsLower))
            {
                throw new ArgumentException("Please enter a last name that starts with an uppercase letter and follows with lowercase letters.");
            }
            if (age < 16 || age > 100)
            {
                throw new ArgumentException("Please enter a valid age. You must be at least 16 years old to use this site.");
            }
        }

        public int CreateVolunteer(string userName, string password, string firstName, string lastName, int age, string contact)
        {

            Validate(userName, password, firstName, lastName, age, contact);
             
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
            Volunteer volunteer = context.Volunteers.FirstOrDefault(v => v.Username == userName);
            if(volunteer != null)
            {
                if(volunteer.Password == password)
                {
                    CurrentSigned.VolunteerId = volunteer.Id;
                    return volunteer.Id;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
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
            if(CurrentSigned.VolunteerId != -1)
            {
                if (context.Volunteers.Find(CurrentSigned.VolunteerId) != null)
                {
                    var currentlySigned = context.Volunteers.Find(CurrentSigned.VolunteerId);
                    var ads = new List<AdvertSingleViewModel>();
                    foreach(JobVolunteer ad in context.JobVolunteer.Where(x=>x.VolunteerId==CurrentSigned.VolunteerId))
                    {
                        var viewAd = context.JobAds.Find(ad.JobAdId);
                        var singleViewModel = new AdvertSingleViewModel()
                        {
                            Id = ad.JobAd.Id,
                            Position = ad.JobAd.PositionName,
                            Description = ad.JobAd.Description,
                            CompanyName = context.Employers.Find(ad.JobAd.EmployerId).CompanyName
                        };
                        ads.Add(singleViewModel);
                    }
                    var singleAdViewModel = new IndexSingleAdViewModel()
                    {
                        Ads = ads
                    };
                    var profileView = new VolunteerProfileViewModel()
                    {
                        Username = currentlySigned.Username,
                        NewPassword = currentlySigned.Password,
                        OldPassword = currentlySigned.Password,
                        FirstName = currentlySigned.FirstName,
                        LastName = currentlySigned.LastName,
                        Age = currentlySigned.Age,
                        Contact = currentlySigned.ContactInformation,
                        SignedInAds = singleAdViewModel
                    };
                    return profileView;
                }
                else
                {
                    throw new ArgumentException("Cannot find the account with the currently specified id.");
                }
            }
            else
            {
                throw new ArgumentException("There is currently no signed in account.");
            }

        }

        
    }
}
