using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core1.ViewModels
{
    public class TripViewModel
    {
        public int ID { get; set; }
        [Required, StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<StopViewModel> Stops { get; set; }
    }
}
