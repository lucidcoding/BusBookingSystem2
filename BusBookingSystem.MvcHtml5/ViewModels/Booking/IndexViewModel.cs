using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusBookingSystem.MvcHtml5.ViewModels.Booking
{
    public class IndexViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public string BusName { get; set; }
    }
}