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

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult LogIn()
        {
            return View();
        }
        public IActionResult FailedLogInAttempt()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            VolunteerDetailViewModel model = service.GetVolunteer(id);
            /*VolunteerDetailViewModel model = new VolunteerDetailViewModel()
            {
                Username = "veselin465",
                FirstName = "Veselin",
                LastName = "Penev",
                Age = 25,
                Contact = "veselinpenev2001@gmail.com"
            };*/
            return View(model);
        }

        public IActionResult Profile()
        {
            VolunteerProfileViewModel model = service.GetSignedVolunteer();
            /*VolunteerProfileViewModel model = new VolunteerProfileViewModel()
            {
                Username = "veselin465",
                FirstName = "Veselin",
                LastName = "Penev",
                Age = 25,
                Contact = "veselinpenev2001@gmail.com"
            };*/

            if (model == null)
            {
                return RedirectToAction("LogIn", "Volunteer");
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
                
                
                return this.View(new VolunteerLogInViewModel() {
                    Username = userName,
                    Password = "",
                    FailedLogInAttempt = true
                });
            }
            
            return this.RedirectToAction("Profile", "Volunteer");
        }

        [HttpPost]
        public IActionResult Profile(string userName, string oldPassword, string newPassword, string firstName, string lastName, int age, string contact)
        {
            bool isSuccessful = false;
            isSuccessful = service.ChangeVolunteer(userName, oldPassword, newPassword, firstName, lastName, age, contact);
            if (isSuccessful)
            {
                return RedirectToAction("", "Volunteer");
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
