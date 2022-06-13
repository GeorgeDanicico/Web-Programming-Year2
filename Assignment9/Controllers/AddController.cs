using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.DataAbstractionLayer;

namespace Assignment9.Controllers
{
    public class AddController : Controller
    {
        public IActionResult Index()
        {
            return View("AddDestination");
        }

        public IActionResult Insert(string city, string country, string description,
                string tourists, string estimated_cost)
        {
            DAL dal = new DAL();

            int userId = (int) HttpContext.Session.GetInt32("userId");

            dal.InsertDestination(city, country, description, 
                tourists, estimated_cost, userId);

            return View("../Main/GetDestination");
        }
    }
}
