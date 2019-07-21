using System;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Text;
using JobSearching.ViewModels;

namespace JobSearching.Services
{
    public class EmployeerService : IEmployerService
    {
        /*
        private JobSearchingDbContext context;
        public EmployeerService(JobSearchingDbContext context)
        {
            this.context = context;
        }
        */

        public int CreateEmployer(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
            throw new NotImplementedException("Impl. CreateEmployer");
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
