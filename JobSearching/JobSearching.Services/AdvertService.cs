using System;
using JobSearching.Data;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Text;
using JobSearching.ViewModels;

namespace JobSearching.Services
{
    public class AdvertService : IAdvertService
    {
        /*
        private JobSearchingDbContext context;
        public AdvertService(JobSearchingDbContext context)
        {
            this.context = context;
        }
        */

        public int CreateAd(int employerId, string position, string descritpion)
        {
            throw new NotImplementedException("Impl. CreateAd");
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
