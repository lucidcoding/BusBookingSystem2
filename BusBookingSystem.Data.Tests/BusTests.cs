using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using BusBookingSystem.Domain.RepositoryContracts;

namespace BusBookingSystem.Data.Tests
{
    [TestClass]
    public class BusTests
    {
        [TestInitialize]
        public void Setup()
        {
            Initializer.Initialize();
        }

        [TestMethod]
        public void CanGetBusses()
        {
            IBusRepository busRepository = Initializer.Kernel.Get<IBusRepository>();
            var busses = busRepository.GetAll();
            Assert.AreEqual(3, busses.Count);
        }
    }
}
