using Core1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Core1.ViewModels;
using AutoMapper;

namespace Core1.Controllers.API
{
    public class TripsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Json()
        {
            TripsRepository db = new TripsRepository();
            JsonResult.Trip = new Trip()
           {
                Name = "First Trip",
               DateCreated = DateTime.Now
           };
            var trips = db.GetAllTrips();
            var results = Mapper.Map<IEnumerable<TripViewModel>>(trips);
            return Json(); // past trips to the JsonResult
        }

    }
}
