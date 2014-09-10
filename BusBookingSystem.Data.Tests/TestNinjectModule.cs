using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using BusBookingSystem.Domain.RepositoryContracts;
using BusBookingSystem.Data.Repositories;

namespace BusBookingSystem.Data.Tests
{
    public class TestNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBusRepository>().To<BusRepository>();
            Bind<IBookingRepository>().To<BookingRepository>();
        }
    }
}
