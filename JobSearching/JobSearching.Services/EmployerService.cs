using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Text;
using JobSearching.ViewModels;
using JobSearching.Data;
using JobSearching.Data.Models;

namespace JobSearching.Services
{
    public class EmployerService : IEmployerService
    {
        
        private JobSearchingDbContext context;
        public EmployerService(JobSearchingDbContext context)
        {
            this.context = context;
        }

        private void Validate(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
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
            if (!middleName.All(char.IsLetter))
            {
                throw new ArgumentException("Please enter a middle name that contains only letters.");
            }
            if (middleName.Length == 1 || middleName.Length > 15)
            {
                throw new ArgumentException("Please enter a middle name with length between 2 and 15 letters.");
            }
            if (!char.IsUpper(middleName[0]) || !middleName.Skip(1).All(char.IsLower))
            {
                throw new ArgumentException("Please enter a middle name that starts with an uppercase letter and follows with lowercase letters.");
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
            if (companyName.Length == 1 || companyName.Length > 60)
            {
                throw new ArgumentException("Please enter a company name with length longer than 1 and shorter than 30 symbols.");
            }
            if (companyLocation.Length < 8)
            {
                throw new ArgumentException("Please specify more thoroughly where the company is situated.");
            }
            if(companyLocation.Length > 100)
            {
                throw new ArgumentException("The company address must be described within 100 symbols.");
            }
            if(contactEmail.Length > 30)
            {
                throw new ArgumentException("The email address entered is too long. Maximum allowed length is 30 symbols.");
            }
            if (!new EmailAddressAttribute().IsValid(contactEmail))
            {
                throw new ArgumentException("Please enter a valid email address. Format: [example@example.com]");
            }
            /*if (!contactPhone.All(char.IsDigit))
            {
                throw new ArgumentException("Please enter a contact phone number that contains only digits.");
            }
            if (contactPhone.Length < 12)
            {
                throw new ArgumentException("Please enter a phone number that consists of 10 digits exactly.");
            }*/
        }

        public int CreateEmployer(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
            Validate(firstName, middleName, lastName, age, companyName, companyLocation, contactEmail, contactEmail);
            var newEmployer = new Employer()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Age = age,
                CompanyName = companyName,
                CurrentAddress = companyLocation,
                ContactEmail = contactEmail,
                ContactPhone = contactPhone,
                JobAds = new List<JobAd>()
            };
            context.Employers.Add(newEmployer);

            context.SaveChanges();

            context.Entry(newEmployer).GetDatabaseValues();
            //secures that object newEmployer will have properly Id

            return newEmployer.Id;
        }

        public EmployerDetailViewModel GetEmployer(int id)
        {
            var employer = context.Employers.Find(id);
            var detailed_employer = new EmployerDetailViewModel()
            {
                FirstName = employer.FirstName,
                MiddleName = employer.MiddleName,
                LastName = employer.LastName,
                Age = employer.Age,
                CompanyName = employer.CompanyName,
                CompanyLocation = employer.CurrentAddress,
                ContactEmail = employer.ContactEmail,
                ContactPhone = employer.ContactPhone
            };
            var model = new EmployerDetailViewModel();
            model.HostAds = GetAllHostedAds(id);
            return model;
        }

        private IndexSingleAdViewModel GetAllHostedAds(int id)
        {
            var hostedAds = new List<AdvertSingleViewModel>();
            foreach(var item in context.JobAds.Where(j => j.EmployerId == id))
            {
                var temp = new AdvertSingleViewModel()
                {
                    Id = item.Id,
                    Position = item.PositionName,
                    Description = item.Description,
                    CompanyName = context.Employers.Find(id).CompanyName
                };
                hostedAds.Add(temp);
            }
            IndexSingleAdViewModel model = new IndexSingleAdViewModel();
            model.Ads = hostedAds;
            return model;
        }

    }
}
