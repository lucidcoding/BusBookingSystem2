using System;
using System.Collections.Generic;
using System.Linq;
using BusBookingSystem.Data.Common;
using BusBookingSystem.Domain.Entities;
using BusBookingSystem.Domain.RepositoryContracts;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace BusBookingSystem.Data.Repositories
{
    public class BookingRepository : Repository, IBookingRepository
    {
        public IList<Booking> GetAll()
        {
            var collection = _database.GetCollection<Booking>("Booking");
            MongoCursor<Booking> cursor = collection.FindAllAs<Booking>();
            return cursor.ToList();
        }

        public Booking GetById(Guid id)
        {
            var collection = _database.GetCollection<Booking>("Booking");
            var query = Query<Booking>.EQ(e => e.Id, id);
            return collection.FindOne(query);
        }

        public void Save(Booking booking)
        {
            var collection = _database.GetCollection<Booking>("Booking");
            collection.Save(booking);
        }

        public void Delete(Guid id)
        {
            var collection = _database.GetCollection<Booking>("Booking");
            var query = Query<Booking>.EQ(e => e.Id, id);
            collection.Remove(query);
        }
    }
}
