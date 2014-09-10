using System;
using System.Collections.Generic;
using BusBookingSystem.Domain.Entities;

namespace BusBookingSystem.Domain.RepositoryContracts
{
    public interface IBusRepository
    {
        IList<Bus> GetAll();
        Bus GetById(Guid id);
        void Save(Bus bus);
    }
}
