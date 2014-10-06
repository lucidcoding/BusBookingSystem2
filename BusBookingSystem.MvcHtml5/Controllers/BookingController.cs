using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusBookingSystem.Domain.RepositoryContracts;
using BusBookingSystem.MvcHtml5.ViewModels.Booking;

namespace BusBookingSystem.MvcHtml5.Controllers
{
    public class BookingController : Controller
    {
        private IBookingRepository _bookingRepository;
        private IBusRepository _busRepository;

        public BookingController(
            IBookingRepository bookingRepository,
            IBusRepository busRepository)
        {
            _bookingRepository = bookingRepository;
            _busRepository = busRepository;
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

        public ActionResult Create()
        {
            var viewModel = new CreateViewModel();
            var busses = _busRepository.GetAll();
            viewModel.BusOptions = new SelectList(busses.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.Value.ToString() }), "Value", "Text");
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create1(CreateViewModel viewModel)
        {
            return View("Done!");
        }

        [HttpPost]
        public ActionResult Create2(CreateViewModel viewModel)
        {
            return View("Done!");
        }
    }
}
