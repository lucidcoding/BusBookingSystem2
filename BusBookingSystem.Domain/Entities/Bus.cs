using BusBookingSystem.Domain.Common;

namespace BusBookingSystem.Domain.Entities
{
    public class Bus : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
