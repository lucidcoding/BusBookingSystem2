using BusBookingSystem.Domain.Common;

namespace BusBookingSystem.Domain.Entities
{
    public class Customer : Entity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
    }
}
