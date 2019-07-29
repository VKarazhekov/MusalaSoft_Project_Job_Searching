using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSearching.Models;
using JobSearching.ViewModels;
using JobSearching.Services.Contracts;

namespace JobSearching.Controllers
{
    public class AdvertController : Controller
    {

        private IAdvertService service;
        public AdvertController(IAdvertService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            AdvertDetailViewModel model = service.GetAd(id);
            /*AdvertDetailViewModel model = new AdvertDetailViewModel()
            {
                CompanyBossFirstName = "Veselin",
                CompanyBossLastName = "Penev",
                CompanyName = "Imaginary Coop.",
                ContactEmail = "veselinpenev2001@gmail.com",
                ContactPhone = "0898420000",
                Position = "German Translator",
                Description = "[EN] Our company needs a German Translator - he / she must be able to speak german very well. \n[DE] Unsere Firma braucht einen deutschen Übersetzer - er / sie muss deutsch wirklich gut können."
            };*/
            return View(model);
        }

        public IActionResult DisplayAllAds()
        {
            IndexSingleAdViewModel model = service.GetAllAds();
            /*List<AdvertSingleViewModel> ads = new List<AdvertSingleViewModel>();
            string[] positionRest = { "HR","Imagnary Coop","Cool Stuff OOD","My Bussiness OOD","Help me OOD", "Everyday Stuff Coop." };
            string[] positions = { "Manager of ", "Secondary manager ", "Children teacher about " };
            string[] companies = { "Imaginary Coop.", "Random Coop.", "Random Stuff OOD" };

            var random = new Random();
            for (int i = 0; i < 3*6; i++)
            {
                ads.Add(new AdvertSingleViewModel()
                {
                    Id = i,
                    CompanyName = companies[random.Next(3)],
                    Position = positions[i%3] + positionRest[i%6],
                    Description = "[EN] The title is clear enough\n[BG] Заглавието е достатъчно ясно\n[DE] Der Titel ist klar genug.[ES] El título es suficientemente claro.\n[FR] Le titre est assez clair.\n[ZH-HANT] 標題很清楚\n[JA] タイトルは十分明確."
                });
            }
            

            IndexSingleAdViewModel model = new IndexSingleAdViewModel()
            {
                Ads = ads
            };*/
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(int employerId, string position, string descritpion)
        {
            try
            {
                this.service.CreateAd(employerId, position, descritpion);
            }
            catch (ArgumentException e)
            {
                return this.View("InvalidAction", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }
            
            return this.RedirectToAction("DisplayAllAds", "Advert");
        }
    }
}
