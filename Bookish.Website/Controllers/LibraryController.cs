using System.Web.Mvc;
using Bookish.ConsoleApp;

namespace Bookish.Website.Controllers
{
    public class LibraryController : Controller
    {
        [HttpPost]
        public ActionResult AddBook(string title, string author, string isbn)
        {
            BookFactory bookFactory = new BookFactory();
            bookFactory.AddBook(title, author, isbn);
            return RedirectToAction("Library", "Home");
        }
    }
}