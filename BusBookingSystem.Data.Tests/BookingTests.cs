using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusBookingSystem.Domain.ParameterSets;
using BusBookingSystem.Domain.Entities;
using Ninject;
using BusBookingSystem.Domain.RepositoryContracts;

namespace BusBookingSystem.Data.Tests
{
    [TestClass]
    public class BookingTests
    {
        [TestInitialize]
        public void Setup()
        {
            Initializer.Initialize();
        }

        [TestMethod]
        public void CanMakeBooking()
        {
            IBookingRepository bookingRepository = Initializer.Kernel.Get<IBookingRepository>();
            IBusRepository busRepository = Initializer.Kernel.Get<IBusRepository>();
            var bertha = busRepository.GetById(new Guid("78396691-1F70-41E0-B82D-8E91EE5A4555"));
            var parameterSet = new MakeEditBookingParameterSet();
            parameterSet.StartDate = new DateTime(2030, 6, 10);
            parameterSet.EndDate = new DateTime(2030, 6, 17);
            parameterSet.Destination = "Scotland";
            parameterSet.Bus = bertha;
            parameterSet.Customers = new List<Customer>();
            parameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Mark", Surname = "Mauve", Address1 = "1 Mauve Street" });
            parameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Rachel", Surname = "Red", Address1 = "1 Red Street" });
            var savedBooking = Booking.Make(parameterSet);
            bookingRepository.Save(savedBooking);
            var savedbookingId = savedBooking.Id.Value;
            var retrievedBooking = bookingRepository.GetById(savedbookingId);
            Assert.AreEqual(savedBooking.StartDate, retrievedBooking.StartDate);
            Assert.AreEqual(savedBooking.EndDate, retrievedBooking.EndDate);
            Assert.AreEqual(savedBooking.Destination, retrievedBooking.Destination);
            Assert.AreSame(savedBooking.Bus, bertha);
            Assert.AreEqual(630m, retrievedBooking.TotalCost);
            Assert.AreEqual(2, retrievedBooking.Customers.Count);
            Assert.IsTrue(retrievedBooking.Customers.Any(x => x.FirstName == "Mark" && x.Surname == "Mauve" && x.Address1 == "1 Mauve Street"));
            Assert.IsTrue(retrievedBooking.Customers.Any(x => x.FirstName == "Rachel" && x.Surname == "Red" && x.Address1 == "1 Red Street"));
        }

        [TestMethod]
        public void CanEditBooking()
        {
            IBookingRepository bookingRepository = Initializer.Kernel.Get<IBookingRepository>();
            IBusRepository busRepository = Initializer.Kernel.Get<IBusRepository>();
            var bertha = busRepository.GetById(new Guid("78396691-1F70-41E0-B82D-8E91EE5A4555"));
            var makeParameterSet = new MakeEditBookingParameterSet();
            makeParameterSet.StartDate = new DateTime(2030, 6, 10);
            makeParameterSet.EndDate = new DateTime(2030, 6, 17);
            makeParameterSet.Destination = "Scotland";
            makeParameterSet.Bus = bertha;
            makeParameterSet.Customers = new List<Customer>();
            makeParameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Mark", Surname = "Mauve", Address1 = "1 Mauve Street" });
            makeParameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Rachel", Surname = "Red", Address1 = "1 Red Street" });
            var savedBooking = Booking.Make(makeParameterSet);
            bookingRepository.Save(savedBooking);
            var savedbookingId = savedBooking.Id.Value;
            var editParameterSet = new MakeEditBookingParameterSet();
            editParameterSet.StartDate = new DateTime(2031, 6, 10);
            editParameterSet.EndDate = new DateTime(2031, 6, 18);
            editParameterSet.Destination = "Wales";
            editParameterSet.Bus = bertha;
            editParameterSet.Customers = new List<Customer>();
            editParameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Barry", Surname = "Blue", Address1 = "1 Blue Street" });
            editParameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Rachel", Surname = "Red", Address1 = "1 Red Street" });
            var retrievedBookingForEdit = bookingRepository.GetById(savedbookingId);
            retrievedBookingForEdit.Edit(editParameterSet);
            bookingRepository.Save(retrievedBookingForEdit);
            var retrievedBooking = bookingRepository.GetById(savedbookingId);
            Assert.AreEqual(editParameterSet.StartDate, retrievedBooking.StartDate);
            Assert.AreEqual(editParameterSet.EndDate, retrievedBooking.EndDate);
            Assert.AreEqual(editParameterSet.Destination, retrievedBooking.Destination);
            Assert.AreSame(editParameterSet.Bus, bertha);
            Assert.AreEqual(720m, retrievedBooking.TotalCost);
            Assert.AreEqual(2, retrievedBooking.Customers.Count);
            Assert.IsTrue(retrievedBooking.Customers.Any(x => x.FirstName == "Barry" && x.Surname == "Blue" && x.Address1 == "1 Blue Street"));
            Assert.IsTrue(retrievedBooking.Customers.Any(x => x.FirstName == "Rachel" && x.Surname == "Red" && x.Address1 == "1 Red Street"));
        }

        [TestMethod]
        public void ChangingBusNameChangesNameInBooking()
        {
            IBookingRepository bookingRepository = Initializer.Kernel.Get<IBookingRepository>();
            IBusRepository busRepository = Initializer.Kernel.Get<IBusRepository>();
            var bertha = busRepository.GetById(new Guid("78396691-1F70-41E0-B82D-8E91EE5A4555"));
            var parameterSet = new MakeEditBookingParameterSet();
            parameterSet.StartDate = new DateTime(2030, 6, 10);
            parameterSet.EndDate = new DateTime(2030, 6, 17);
            parameterSet.Destination = "Scotland";
            parameterSet.Bus = bertha;
            parameterSet.Customers = new List<Customer>();
            parameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Mark", Surname = "Mauve", Address1 = "1 Mauve Street" });
            parameterSet.Customers.Add(new Customer { Id = Guid.NewGuid(), FirstName = "Rachel", Surname = "Red", Address1 = "1 Red Street" });
            var savedBooking = Booking.Make(parameterSet);
            bookingRepository.Save(savedBooking);
            bertha.Name = "Bertha Changed";
            busRepository.Save(bertha);
            var savedbookingId = savedBooking.Id.Value;
            var retrievedBooking = bookingRepository.GetById(savedbookingId);
            Assert.AreEqual("Bertha Changed", retrievedBooking.Bus.Name);
        }
    }
}
