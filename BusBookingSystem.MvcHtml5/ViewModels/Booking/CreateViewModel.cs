using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusBookingSystem.MvcHtml5.ViewModels.Booking
{
    public class CreateViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public Guid BusId { get; set; }
        public SelectList BusOptions { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}