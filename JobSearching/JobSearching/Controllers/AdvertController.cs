using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSearching.Models;
using JobSearching.ViewModels;

namespace JobSearching.Controllers
{
    public class AdvertController : Controller
    {

        /*private IAdvertService service;
        public VolunteerController(IAdvertService service)
        {
            this.service = service;
        }*/

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult DisplayAllAds()
        {
            //IndexSingleAdViewModel model = service.GetAllAds();
            return View();
        }

        public IActionResult Detail(int id)
        {
            //AdvertDetailViewModel model = service.GetAd(id);
            AdvertDetailViewModel model = new AdvertDetailViewModel()
            {
                CompanyBossFirstName = "Veselin"+id,
                CompanyBossLastName = "Penev",
                CompanyName = "Imaginary Coop.",
                ContactEmail = "veselinpenev2001@gmail.com",
                ContactPhone = "0898420000",
                Position = "German Translator",
                Description = "[EN] Our company needs a German Translater - he / she must be able to speak german very well. [DE] Unsere Firma braucht einen deutschen Übersetzer - er muss deutsch wirklich gut können."
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(int employerId, string position, string descritpion)
        {
            try
            {
                /*this.service.CreateAd(employerId, position, descritpion);*/
            }
            catch (Exception e)
            {
                return this.View("Error", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }
            
            return this.RedirectToAction("DisplayAllAds", "Advert");
        }
    }
}
