using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core1.Models
{
    public class TripsRepository
    {
        TripContext db = new TripContext();
        public IEnumerable<Trip> GetAllTrips()
        {
          return db.Trips.Include(a => a.Stops).OrderBy(t =>t.Name).ToList();
        }

        public Trip GetTrip(int id)
        {
            var trip = db.Trips.Include(s => s.Stops).Where(a => a.ID == id).Single();
            return trip;
        }
        public void SaveTrip(Trip t)
        {
            db.Add(t);
            db.SaveChanges();
        }

        public IEnumerable<Stop> GetStops(string name)
        {
            var trip = db.Trips.Include(t => t.Stops).Where(t => t.Name == name).Single();
            return trip.Stops
                //.Include(s => s.stop.ID)
                .OrderBy(t => t.Order).Where(t => t.Name == name).ToList();
                
        }

        public void AddStop(Stop s)
        {
            db.Stops.Add(s);
            db.SaveChanges();
        }
    }
}
