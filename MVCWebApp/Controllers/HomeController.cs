using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Business;
using DataAccess;

namespace MVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPersonService personService)
        {
     /*       IEnumerable<Person> people = personService.GetAll();
            Person person;
            for (int i = 0; i < 100; i++)
            {
                person = people.ElementAt(i);
                Trace.WriteLine(string.Format("{0} {1}", person.FirstName, person.LastName));
            }*/
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

        public ActionResult Index()
        {
            return View();
        }
    }
}