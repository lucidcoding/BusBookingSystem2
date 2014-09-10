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
    public class BusRepository : Repository, IBusRepository
    {
        public IList<Bus> GetAll()
        {
            var collection = _database.GetCollection<Bus>("Bus");
            MongoCursor<Bus> cursor = collection.FindAllAs<Bus>();
            return cursor.ToList();
        }

        public Bus GetById(Guid id)
        {
            var collection = _database.GetCollection<Bus>("Bus");
            var query = Query<Bus>.EQ(e => e.Id, id);
            return collection.FindOne(query);
        }

        public void Save(Bus bus)
        {
            var collection = _database.GetCollection<Bus>("Bus");
            collection.Save(bus);
        }
    }
}
