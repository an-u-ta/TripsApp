using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Core1.Models;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Core1.Controllers.Web
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
       // [Authorize]
        public IActionResult Index()
        {
            TripsRepository db = new TripsRepository();
            ViewBag.Trip = new Trip()
            {
                Name = "Sample Trip",
                DateCreated = DateTime.Now,
                UserName = "Enter your name: "
            };
            var trips = db.GetAllTrips();
            return View(trips); // past trips to the view
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
