using System;
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

        private void Validate()
        {
            throw new NotImplementedException();
            /// Throw new ArgumentException("Explain what is the problem")
        }

        public int CreateEmployer(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
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
