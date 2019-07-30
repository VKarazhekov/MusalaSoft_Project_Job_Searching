using JobSearching.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Services.Contracts
{
    public interface IEmployerService
    {
        int CreateEmployer(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone);
        EmployerDetailViewModel GetEmployer(int id);
        //IndexSingleAdViewModel GetAllHostedAds(int id);

    }
}
