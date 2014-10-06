using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Domain.RepositoryContracts;
using BusBookingSystem.Html5.ViewModels.Booking;

namespace BusBookingSystem.Html5.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public ActionResult Index()
        {
            var bookings = _bookingRepository.GetAll();

            var viewModel = bookings.Select(x => new IndexViewModel
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Destination = x.Destination,
                BusName = x.Bus.Name
            });

            return View(viewModel);
        }

    }
}
