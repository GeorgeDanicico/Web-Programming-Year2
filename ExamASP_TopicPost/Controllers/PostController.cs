using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamASP_TopicPost.DataAbstractionLayer;

namespace ExamASP_TopicPost.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View("MainPage");
        }

        public IActionResult ModifyPost(string postid, string text)
        {
            DateTime date = DateTime.Now;
            int postId = Int32.Parse(postid);
            string user = HttpContext.Session.GetString("user");

            DAL dal = new DAL();
            dal.UpdatePost(postId, text, user, date);

            return View("MainPage");
        }

        public string CheckUpdates()
        {
            string user = HttpContext.Session.GetString("user");
            string oldList = HttpContext.Session.GetString("old_state");
            DAL dal = new DAL();
            string newList = dal.GetAllPosts(user);
            string response = "New updates: ";
            if (oldList != newList)
            {
                string[] oldListSplit = oldList.Split("/");
                string[] newListSplit = newList.Split("/");

                for (int i = 0; i < newListSplit.Length; i++)
                {
                    if (i >= oldListSplit.Length)
                    {
                        response += newListSplit[i] + "/";
                    }
                }
                HttpContext.Session.SetString("old_state", newList);
                 return response;
            }

            return "no";
        }

        public IActionResult AddPost(string topicname, string text)
        {
            DateTime date = DateTime.Now;
            string user = HttpContext.Session.GetString("user");

            DAL dal = new DAL();
            int topicId = dal.GetTopicId(topicname);
            Console.WriteLine("topic id: " + topicId);

            dal.AddPost(topicId, text, user, date);

            return View("MainPage");
        }
    }
}
