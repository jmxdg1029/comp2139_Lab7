using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab7.Models
{
    public class Trip
    {

        public int TripId { get; set; }
        [Required(ErrorMessage="Please enter a destination")]
        public string Destination { get; set; }
        [Required(ErrorMessage = "Please enter a valid Start Date")]
        public DateTime startDate { get; set; }
        [Required(ErrorMessage = "Please enter a valid End Date ")]
        public DateTime endDate { get; set; }
        public string Accomidation { get; set; }
        public string AccommodationEmail { get; set; }
        public string AccommodationPhone { get; set; }
        public string ThingToDo1 { get; set; }
        public string ThingToDo2 { get; set; }
        public string ThingToDo3 { get; set; }
    }
}
