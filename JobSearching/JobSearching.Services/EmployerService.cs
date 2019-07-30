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
            if (firstName.Length == 1 || firstName.Length > 20)
            {
                throw new ArgumentException("Please enter a first name with length between 2 and 20 letters.");
            }
            if (!middleName.All(char.IsLetter))
            {
                throw new ArgumentException("Please enter a middle name that contains only letters.");
            }
            if (middleName.Length == 1 || middleName.Length > 20)
            {
                throw new ArgumentException("Please enter a middle name with length between 2 and 20 letters.");
            }
            if (!lastName.All(char.IsLetter))
            {
                throw new ArgumentException("Please enter a last name that contains only letters.");
            }
            if (lastName.Length == 1 || lastName.Length > 20)
            {
                throw new ArgumentException("Please enter a last name with length between 2 and 20 letters.");
            }
            if (age < 16 || age > 100)
            {
                throw new ArgumentException("Please enter a valid age. You must be at least 16 years old to use this site.");
            }
            if (companyName.Length == 1 || companyName.Length > 30)
            {
                throw new ArgumentException("Please enter a company name with length longer than 1 and shorter than 30 symbols.");
            }
            if (companyLocation.Length < 8)
            {
                throw new ArgumentException("Please specify more thoroughly where the company is situated.");
            }
            if(companyLocation.Length > 50)
            {
                throw new ArgumentException("The company address must be described within 50 symbols.");
            }
            if (!new EmailAddressAttribute().IsValid(contactEmail))
            {
                throw new ArgumentException("Please enter a valid email address. Format: [example@example.com]");
            }
            /*if (!contactPhone.All(char.IsDigit))
            {
                throw new ArgumentException("Please enter a contact phone number that contains only digits.");
            }
            if (contactPhone.Length!=11)
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
            // виж EmployerController -> Detail();
            throw new NotImplementedException("Impl. GetEmployer(id)");
        }

        public IndexSingleAdViewModel GetAllHostedAds(int id)
        {
            throw new NotImplementedException("Impl. GetAllHostedAds(id)");
        }

    }
}
