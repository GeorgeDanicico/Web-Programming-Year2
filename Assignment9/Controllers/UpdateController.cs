using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment9.Models;
using Assignment9.DataAbstractionLayer;

namespace Assignment9.Controllers
{
    public class UpdateController : Controller
    {
        public IActionResult Index()
        {
            DAL dal = new DAL();
            int itemId = (int)HttpContext.Session.GetInt32("destId");
            Destination dest = dal.GetDestination(itemId);

            ViewData["destination"] = dest;

            return View("Update");
        }
        
        public IActionResult Update(string city, string country, string description,
                 string tourists, string estimated_cost)
        {
            DAL dal = new DAL();

            int userId = (int)HttpContext.Session.GetInt32("userId");
            int itemId = (int)HttpContext.Session.GetInt32("destId");
            Console.WriteLine(itemId + ", " + userId);

            dal.UpdateDestination(itemId, city, country, description,
                tourists, estimated_cost);

            return View("../Main/GetDestination");
        }
    }
}
