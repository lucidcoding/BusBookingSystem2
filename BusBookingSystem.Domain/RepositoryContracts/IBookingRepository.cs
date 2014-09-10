using System;
using System.Collections.Generic;
using BusBookingSystem.Domain.Entities;

namespace BusBookingSystem.Domain.RepositoryContracts
{
    public interface IBookingRepository
    {
        IList<Booking> GetAll();
        Booking GetById(Guid id);
        void Save(Booking bus);
        void Delete(Guid id);
    }
}
