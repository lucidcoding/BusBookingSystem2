using System;
using System.Reflection;
using BusBookingSystem.Domain.Entities;
using BusBookingSystem.Domain.RepositoryContracts;
using MongoDB.Driver;
using Ninject;

namespace BusBookingSystem.Data.Tests
{
    public static class Initializer
    {
        public static IKernel Kernel;

        public static void Initialize()
        {
            Kernel = new StandardKernel();
            Kernel.Load(Assembly.GetExecutingAssembly());
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("BusBookingSystem");
            database.DropCollection("Bus");
            database.DropCollection("Booking");
            IBusRepository busRepository = Kernel.Get<IBusRepository>();
            busRepository.Save(new Bus { Id = new Guid("78396691-1F70-41E0-B82D-8E91EE5A4555"), Name = "Bertha", Description = "1979 Super Viking" });
            busRepository.Save(new Bus { Id = new Guid("7F58A475-125D-4DE6-A105-D0365C855900"), Name = "Thurston", Description = "1969 Westfalia" });
            busRepository.Save(new Bus { Id = new Guid("9F056E34-5628-43F3-B534-3563842A9E98"), Name = "Franklin", Description = "1965 Deluxe Microbus" });
        }
    }
}
