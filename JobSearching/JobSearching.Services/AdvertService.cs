using System;
using JobSearching.Data;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Text;
using JobSearching.ViewModels;
using JobSearching.Data.Models;

namespace JobSearching.Services
{
    public class AdvertService : IAdvertService
    {
        
        private JobSearchingDbContext context;
        public AdvertService(JobSearchingDbContext context)
        {
            this.context = context;
        }


        private void Validate()
        {
            throw new NotImplementedException();
            /// Throw new ArgumentException("Explain what is the problem")
        }

        public int CreateAd(int employerId, string position, string descritpion)
        {
            //// Validate();
            //// MUST HAVE VALIDATION

            var newAd = new JobAd()
            {
                EmployerId = employerId,
                PositionName = position,
                Description = descritpion,
                Employer = context.Employers.Find(employerId)
            };

            context.JobAds.Add(newAd);

            context.SaveChanges();

            context.Entry(newAd).GetDatabaseValues();
            //secures that object newVolunteer will have properly Id

            return newAd.Id;
        }


        public AdvertDetailViewModel GetAd(int id)
        {
            // виж AdvertController -> Detail();
            throw new NotImplementedException("Impl. GetAd(id)");
        }


        public IndexSingleAdViewModel GetAllAds()
        {
            throw new NotImplementedException("Impl. GetAllAds");
        }


        public int SignVolunteerToAnAdd(int advertId)
        {
            // Тук се прави връзката м/у реклама и потребител (JobVolunteer)
            // Използвай синтаксис CurrentSigned.VolunteerId (статично)
            throw new NotImplementedException("Impl. Map advert+volunteer");
        }

    }
}
