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
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            ViewData.Add("data", "data");
            return View("GetDestination");
        }

        public IActionResult AddPage()
        {
            return View("AddController");
        }

        public string Test()
        {
            return "It's working";
        }

        public void UpdateDestination(int destId)
        {
            HttpContext.Session.SetInt32("destId", destId);
        }

        public string GetAllDestinations()
        {
            DAL dal = new DAL();

            int userId = (int) HttpContext.Session.GetInt32("userId");
            List<Destination> dlist = dal.GetDestinations(userId);

            string result = "<table><tr><th>Id</th><th>Description</th><th>City</th><th>Country</th>" +
                "<th>Tourists Target</th><th>Estimated cost</th><th>Action</th></tr>";

            foreach (Destination dest in dlist)
            {
                result += "<tr><td>" + dest.Id + "</td><td>" + dest.Description + "</td><td>" + dest.City + "</td><td>" + dest.Country + "</td><td>" + 
                    dest.TouristTarget + "</td><td>" + dest.EstimatedCost + "</td><td><button id=" + dest.Id + " class='update-button'>Update</button><button id="+ dest.Id + " class='delete-button'>Delete</button></td></tr>";
            }

            result += "</table>";
            return result;
        }

        public void DeleteDestination(int destId)
        {
            DAL dal = new DAL();

            dal.DeleteDestination(destId);
        }
    }
}
