using FinalExamASP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FinalExamASP.DataAbstractionLayer;

namespace FinalExamASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEntry(string key, string value)
        {
            DAL dal = new DAL();
            dal.AddEntry(key, value);

            return View("Index");
        }

        public string GetDocuments(string title)
        {
            DAL dal = new DAL();

            List<Document> documents = dal.GetDocuments(title);
            Console.WriteLine("got here");
            string result = "<table><tr><th>Id</th><th>Title</th><th>List Of Templates</th><th>Select</th></tr>";

            int index = 1;
            foreach (Document doc in documents)
            {
                string cls = "normal";
                if (index % 2 == 0) cls = "highlight";
                index++;
                result += "<tr class='" + cls + "'><td>" + doc.Id + "</td><td>" + doc.Title + "</td><td>" + doc.ListOfTemplates + "</td>" +
                    "<td><button id=" + doc.Id + " class='select-button'>select</button></tr>";
            }

            result += "</table>";
            return result;
        }

        public string GetTemplates(string docId)
        {
            int docid = Int32.Parse(docId);
            Console.WriteLine(docid);
            DAL dal = new DAL();
            string result = dal.GetTemplates(docid);
            
            return result;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
