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
            return db.Trips.OrderBy(t => t.Name).ToList();
        }
    }
}
