using System;
using System.Linq;
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
        
        private void Validate(int employerId, string position, string description)
        {
            if(context.Employers.Find(employerId) == null)
            {
                throw new ArgumentException($"Cannot find the employer with id = {employerId}");
            }
            if (position.Length > 25)
            {
                if(!position.All(char.IsLetter))
                {
                    throw new ArgumentException("The name of the position cannot contain numbers. Please enter a name that doesn't contain numbers.");
                }
                throw new ArgumentException("The length of the position name exceeds 20 symbols. Please enter a shorter name for the position.");
            }
            if(description.Length > 500)
            {
                throw new ArgumentException("The description length exceeds 500 symbbols. Please enter a shorter description.");
            }
        }

        public int CreateAd(int employerId, string position, string description)
        {
            Validate(employerId, position, description);
            var newAd = new JobAd()
            {
                EmployerId = employerId,
                PositionName = position,
                Description = description,
                Employer = context.Employers.Find(employerId)
            };

            context.JobAds.Add(newAd);

            context.SaveChanges();

            context.Entry(newAd).GetDatabaseValues();
            //secures that object newVolunteer will have proper Id

            return newAd.Id;
        }


        public AdvertDetailViewModel GetAd(int id)
        {
            // виж AdvertController -> Detail();
            //throw new NotImplementedException("Impl. GetAd(id)");
            var ad = context.JobAds.Find(id);
            if (ad == null)
            {
                throw new ArgumentException("Cannot find the specified ad.");
            }
            var employer = context.Employers.Find(ad.EmployerId);
            if(employer == null)
            {
                throw new ArgumentException("Cannot find the employer associated with the ad.");
            }
            var detailedAd = new AdvertDetailViewModel()
            {
                CompanyBossFirstName = employer.FirstName,
                CompanyBossLastName = employer.LastName,
                CompanyName = employer.CompanyName,
                CompanyLocation = employer.CurrentAddress,
                Position = ad.PositionName,
                Description = ad.Description,
                ContactEmail = employer.ContactEmail,
                ContactPhone = employer.ContactPhone
            };
            return detailedAd;
        }


        public IndexSingleAdViewModel GetAllAds()
        {
            //throw new NotImplementedException("Impl. GetAllAds");
            var availableAds = new List<AdvertSingleViewModel>();
            foreach(var item in context.JobAds)
            {
                var ad = new AdvertSingleViewModel
                {
                    Id = item.Id,
                    Position = item.PositionName,
                    Description = item.Description,
                    CompanyName = context.Employers.First(e => e.Id == item.EmployerId).CompanyName
                };
                availableAds.Add(ad);
            }
            var db_ads = new IndexSingleAdViewModel();
            db_ads.Ads = availableAds;
            return db_ads;
        }


        public int SignVolunteerToAnAd(int advertId)
        {
            // Тук се прави връзката м/у реклама и потребител (JobVolunteer)
            // Използвай синтаксис CurrentSigned.VolunteerId (статично)
            throw new NotImplementedException("Impl. Map advert+volunteer");
        }

    }
}
