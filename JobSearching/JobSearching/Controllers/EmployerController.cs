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
    public class EmployerController : Controller
    {

        private IEmployerService service;
        public EmployerController(IEmployerService service)
        {
            this.service = service;
        }

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Detail(int id)
        {
            EmployerDetailViewModel model;

            /*var ads = new List<AdvertSingleViewModel>();
            for (int i = 0; i < 20; i++) {
                ads.Add(new AdvertSingleViewModel()
                {
                    Id = (i+1),
                    Position = "Any pos pos pos",
                    Description = "Any Description"
                });
            }
            
            model = new EmployerDetailViewModel()
            {
                FirstName = "Veselin" + id,
                MiddleName = "Hristov",
                LastName = "Penev",
                CompanyName = "Imaginary Coop.",
                ContactEmail = "veselinpenev2001@gmail.com",
                ContactPhone = "0898420000",
                Age = 30,
                CompanyLocation = "Bulgaria, Sofia",
                HostAds = new IndexSingleAdViewModel() { Ads = ads }
                
            };*/

            try
            {
                model = service.GetEmployer(id);
            }
            catch (IndexOutOfRangeException)
            {
                return this.View("InvalidAction", new InvalidActionViewModel() { ErrorMessage = "Failed to execute last command:\nIndex was out of range" });
            }
            catch (ArgumentException e)
            {
                return this.View("InvalidAction", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }

            return View(model);
        }


        [HttpPost]
        public IActionResult Create(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
            try
            {
                this.service.CreateEmployer(firstName, middleName, lastName, age, companyName, companyLocation, contactEmail, contactPhone);
            }
            catch (ArgumentException e)
            {
                return this.View("InvalidAction", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }
            return this.RedirectToAction("Create", "Advert");
        }

    }
}
