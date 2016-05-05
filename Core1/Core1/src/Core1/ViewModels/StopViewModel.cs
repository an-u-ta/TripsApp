using System;
using System.ComponentModel.DataAnnotations;

namespace Core1.ViewModels
{
    public class StopViewModel
    {
        public int ID { get; set; }
        [Required, StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime ArrivalDate { get; set; }
    }
}