using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusBookingSystem.Domain.RepositoryContracts;
using System.Web.Mvc;
using BusBookingSystem.Domain.Entities;
using BusBookingSystem.Domain.ParameterSets;
using BusBookingSystem.WebApi.Requests;

namespace BusBookingSystem.WebApi.Controllers
{
    //Resources:
    //http://www.prideparrot.com/blog/archive/2012/3/creating_a_rest_service_using_asp_net_web_api
    //http://www.asp.net/web-api/overview/creating-web-apis/creating-a-web-api-that-supports-crud-operations
    //[AllowCrossSite]
    public class BookingController : ApiController
    {
        private IBookingRepository _bookingRepository;
        private IBusRepository _busRepository;

        //Becuse of bug with Ninject and WebApi
        public BookingController()
        {
            _bookingRepository = DependencyResolver.Current.GetService<IBookingRepository>();
            _busRepository = DependencyResolver.Current.GetService<IBusRepository>();
        }

        public BookingController(
            IBookingRepository bookingRepository, 
            IBusRepository busRepository)
        {
            _bookingRepository = bookingRepository;
            _busRepository = busRepository;
        }

        public IEnumerable<Booking> Get()
        {
            return _bookingRepository.GetAll();
        }

        public Booking Get(Guid id)
        {
            return _bookingRepository.GetById(id);
        }

        public HttpResponseMessage Post(MakeEditBookingRequest request)
        {
            var parameterSet = new MakeEditBookingParameterSet();
            parameterSet.Id = request.Id;
            parameterSet.StartDate = request.StartDate;
            parameterSet.EndDate = request.EndDate;
            parameterSet.Destination = request.Destination;
            parameterSet.Bus = _busRepository.GetById(request.BusId);
            parameterSet.Customers = request.Customers;
            Booking booking = null;

            if (parameterSet.Id.HasValue)
            {
                booking = _bookingRepository.GetById(parameterSet.Id.Value);
                booking.Edit(parameterSet);
            }
            else
            {
                booking = Booking.Make(parameterSet);
            }

            _bookingRepository.Save(booking);
            var response = Request.CreateResponse<Booking>(HttpStatusCode.Created, booking);
            string uri = Url.Link("Default", new { controller = "Booking", action = "Get", id = booking.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void Put(MakeEditBookingParameterSet parameterSet)
        {
            var booking = _bookingRepository.GetById(parameterSet.Id.Value);
            booking.Edit(parameterSet);
            _bookingRepository.Save(booking);
        }

        public HttpResponseMessage Delete(Guid id)
        {
            _bookingRepository.Delete(id);

            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent
            };
        }
    }
}
