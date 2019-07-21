using JobSearching.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace JobSearching.Services.Contracts
{
    public interface IAdvertService
    {

        AdvertDetailViewModel GetAd(int id);
        IndexSingleAdViewModel GetAllAds();
        int CreateAd(int employerId, string position, string descritpion);
        int SignVolunteerToAnAdd(int advertId);
    }
}
