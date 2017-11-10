using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.ConsoleApp;
using Dapper;

namespace Bookish.Website.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Library()
        {
            ViewBag.Message = "Your library page.";
            BookFactory bookFactory = new BookFactory();
            Dictionary<Book, BookAvailabilityHelper> bookDict = bookFactory.GetDictOfBooks();

            return View(bookDict);
        }
    }
}