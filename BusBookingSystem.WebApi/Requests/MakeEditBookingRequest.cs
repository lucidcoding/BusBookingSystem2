using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusBookingSystem.Domain.Entities;

namespace BusBookingSystem.WebApi.Requests
{
    public class MakeEditBookingRequest
    {
        public Guid? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public Guid BusId { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}