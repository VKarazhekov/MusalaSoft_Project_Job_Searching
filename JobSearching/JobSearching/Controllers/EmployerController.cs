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
    public class EmployerController : Controller
    {

        /*private IEmployerService service;
        public VolunteerController(IEmployerService service)
        {
            this.service = service;
        }*/

        public IActionResult Create()
        {
            return this.View();
        }

        public IActionResult Detail(int id)
        {
            //EmployerDetailViewModel model = service.GetEmployer(id);
            EmployerDetailViewModel model = new EmployerDetailViewModel()
            {
                FirstName = "Veselin"+id,
                MiddleName = "Hristov",
                LastName = "Penev",
                CompanyName = "Imaginary Coop.",
                ContactEmail = "veselinpenev2001@gmail.com",
                ContactPhone = "0898420000",
                Age = 30,
                CompanyLocation = "Bulgaria, Sofia"
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(string firstName, string middleName, string lastName, int age, string companyName, string companyLocation, string contactEmail, string contactPhone)
        {
            try
            {
                /*this.service.CreateEmployer(firstName, middleName, lastName, age, companyName, companyLocation, contactEmail, contactPhone);*/
            }
            catch (Exception e)
            {
                return this.View("Error", new InvalidActionViewModel() { ErrorMessage = e.Message });
            }
            return this.RedirectToAction("LogIn", "Volunteer");
        }

    }
}
