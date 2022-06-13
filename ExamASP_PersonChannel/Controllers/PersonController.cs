using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using ExamASP_PersonChannel.DataAbstractionLayer;
using ExamASP_PersonChannel.Models;

namespace ExamASP_PersonChannel.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View("MainPage");
        }

        public string GetAllChannels(string user)
        {
            DAL dal = new DAL();
            Console.WriteLine(user);
            List<Channel> dlist = dal.GetChannels(user);

            string result = "<table><tr><th>Id</th><th>Owner ID</th><th>Name</th><th>Description</th>" +
                "<th>Subscribers</th></tr>";

            foreach (Channel ch in dlist)
            {
                result += "<tr><td>" + ch.Id + "</td><td>" + ch.OwnerId + "</td><td>" + ch.Name + "</td><td>" + ch.Description + "</td><td>" +
                    ch.subscribers + "</td></tr>";
            }

            result += "</table>";
            return result;
        }

        public string GetMyChannels()
        {
            DAL dal = new DAL();
            string user = HttpContext.Session.GetString("user");
            Console.WriteLine(user);
            List<Channel> dlist = dal.GetAllChannels();

            string result = "<table><tr><th>Name</th><th>Description</th></tr>";

            foreach (Channel ch in dlist)
            {
                string subs = ch.subscribers;
                string[] splitsubs = subs.Split("/");

                foreach (var subscriber in splitsubs)
                {
                    string[] data = subscriber.Split(";");

                    if (data[1] == user)
                    {
                        result += "<tr><td>" + ch.Name + "</td><td>" + ch.Description + "</td><td></tr>";
                        break;
                    }
                }
            }

            result += "</table>";
            return result;
        }

        public void SubscribePerson(string channelName)
        {
            string user = HttpContext.Session.GetString("user");
            DAL dal = new DAL();
            Channel ch = dal.GetChannel(channelName);

            string subs = ch.subscribers;
            string[] splitsubs = subs.Split("/");
            string newSubs = "";
            bool found = false;

            foreach (var subscriber in splitsubs)
            {
                string[] data = subscriber.Split(";");

                if (data[1] == user)
                {
                    DateTime date = DateTime.Now;

                    newSubs = newSubs + "/" + data[0] + ";" + data[1] + ";" + data[2] + ";" + date.Day + "-" + date.Month + "-" + date.Year;
                    found = true;
                } else
                {
                    if (newSubs == "") newSubs = subscriber;
                    else 
                        newSubs += "/" + subscriber;
                }
            }
            if (!found)
            {
                string p = dal.GetPerson(user);
                DateTime date = DateTime.Now;
                if (newSubs == "") newSubs = p + date.Day + "-" + date.Month + "-" + date.Year;
                else newSubs += "/" + p + date.Day + "-" + date.Month + "-" + date.Year;
            }

            dal.UpdateChannel(channelName, newSubs);
        }
    }
}
