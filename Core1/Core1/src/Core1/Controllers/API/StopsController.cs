using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Core1.Models;
using AutoMapper;
using Core1.ViewModels;
using Core1.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Core1.Controllers.API
{
    [Route("api/[controller]/{tripName}")]
    public class StopsController : Controller
    {
        TripsRepository db = new TripsRepository();
        public CoordinateService coorService = new CoordinateService();
        // GET: api/values
        [HttpGet]
        public JsonResult Get(string tripName)
        {
            var stop = db.GetStops(tripName); 
            var results = Mapper.Map<IEnumerable<TripViewModel>>(stop);
            return Json(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public async Task<JsonResult> Post(StopViewModel stop)
        {
            var newStop = Mapper.Map<Stop>(stop);
            var longlat = await coorService.Lookup(newStop.Name);
            if (longlat.Success)
            {
                db.AddStop(newStop);
            }
            return Json(newStop);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
