using System;
using System.Collections.Generic;
using BusBookingSystem.Domain.Common;
using BusBookingSystem.Domain.ParameterSets;

namespace BusBookingSystem.Domain.Entities
{
    public class Booking : Entity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Destination { get; set; }
        public Bus Bus { get; set; }
        public IList<Customer> Customers { get; set; }
        public decimal TotalCost { get; set; }

        public static Booking Make(MakeEditBookingParameterSet parameterSet)
        {
            var booking = new Booking();
            booking.Id = Guid.NewGuid();
            booking.StartDate = parameterSet.StartDate;
            booking.EndDate = parameterSet.EndDate;
            booking.Destination = parameterSet.Destination;
            booking.Bus = parameterSet.Bus;
            booking.Customers = parameterSet.Customers;
            booking.TotalCost = (parameterSet.EndDate - parameterSet.StartDate).Days * 90;
            return booking;
        }

        public void Edit(MakeEditBookingParameterSet parameterSet)
        {
            StartDate = parameterSet.StartDate;
            EndDate = parameterSet.EndDate;
            Destination = parameterSet.Destination;
            Bus = parameterSet.Bus;
            Customers = parameterSet.Customers;
            TotalCost = (parameterSet.EndDate - parameterSet.StartDate).Days * 90;
        }
    }
}
