using System;
using JobSearching.Services.Contracts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSearching.Models;
using JobSearching.ViewModels;
using JobSearching.Services;

namespace JobSearching.Controllers
{
    public class VolunteerController : Controller
    {


        private IVolunteerService service;
        public VolunteerController(IVolunteerService service)
        {
            this.service = service;
        }

        public IActionResult SuccessfulAction()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }

        public IActionResult LogInError()
        {

            string username = (TempData["username"]!=null) ? TempData["username"].ToString() : "";
            string errorMsg = (TempData["errorMsg"] != null) ? TempData["errorMsg"].ToString() : "";

            if (errorMsg == "") return View("LogIn");

            return View("LogIn",new VolunteerLogInViewModel()
            {
                Username = username,
                Password = "",
                ErrorMessage = errorMsg
            });
        }

        public IActionResult Detail(int id)
        {
            VolunteerDetailViewModel model;

            /*model = new VolunteerDetailViewModel()
            {
                Username = "veselin465",
                FirstName = "Veselin",
                LastName = "Penev",
                Age = 25,
                Contact = "veselinpenev2001@gmail.com"
            };*/

            try
            {
                model = service.GetVolunteer(id);
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

        public IActionResult Profile()
        {
            VolunteerProfileViewModel model;

            /*var ads = new List<AdvertSingleViewModel>();
            for (int i = 0; i < 20; i++)
            {
                ads.Add(new AdvertSingleViewModel()
                {
                    Id = (i + 1),
                    Position = "Any pos pos pos",
                    Description = "Any Description"
                });
            }
            
            model = new VolunteerProfileViewModel()
            {
                Username = "veselin465",
                FirstName = "Veselin",
                LastName = "Penev",
                Age = 25,
                Contact = "veselinpenev2001@gmail.com",
                SignedInAds = new IndexSingleAdViewModel() { Ads = ads }

            };*/

            try
            {
                model = service.GetSignedVolunteer();
            }
            catch (ArgumentException e)
            {
                TempData["username"] = "";
                TempData["errorMsg"] = e.Message; //"You need to be logged in"
                return LogInError();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(string userName, string password, string firstName, string lastName, int age, string contact)
        {
            try
            {
                this.service.CreateVolunteer(userName, password, firstName, lastName, age, contact);
            }
            catch (ArgumentException e)
            {
                return this.View("InvalidAction", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }
           
            return this.RedirectToAction("LogIn", "Volunteer");
        }

        [HttpPost]
        public IActionResult LogIn(string userName, string password)
        {
            int id = -1;
            id = this.service.LogInVolunteer(userName, password);

            if (id == -1)
            {
                TempData["username"] = userName;
                TempData["errorMsg"] = "Failed LogIn Attempt";
                return LogInError();
            }
            
            return this.RedirectToAction("SuccessfulAction", "Volunteer");
        }

        [HttpPost]
        public IActionResult Change(string userName, string oldPassword, string newPassword, string firstName, string lastName, int age, string contact)
        {
            bool isSuccessful = false;
            isSuccessful = service.ChangeVolunteer(userName, oldPassword, newPassword, firstName, lastName, age, contact);
            if (isSuccessful)
            {
                return RedirectToAction("SuccessfulAction", "Volunteer");
            }
            else
            {
                return RedirectToAction("Profile", "Volunteer", new VolunteerProfileViewModel()
                {
                    Username = userName, FirstName = firstName, LastName = lastName,
                    Age = age, Contact = contact
                });
            }
        }
    }
}
