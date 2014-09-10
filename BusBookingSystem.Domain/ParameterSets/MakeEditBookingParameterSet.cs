using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusBookingSystem.Domain.Entities;

namespace BusBookingSystem.Domain.ParameterSets
{
    public class MakeEditBookingParameterSet
    {
        public Guid? Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public Bus Bus { get; set; }
        public IList<Customer> Customers { get; set; }
    }
}
