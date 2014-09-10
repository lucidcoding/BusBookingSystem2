using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusBookingSystem.Domain.RepositoryContracts;
using BusBookingSystem.Domain.Entities;
using System.Web.Mvc;

namespace BusBookingSystem.WebApi.Controllers
{
    public class BusController : ApiController
    {
        private IBusRepository _busRepository;

        //Becuse of bug with Ninject and WebApi
        public BusController()
        {
            _busRepository = DependencyResolver.Current.GetService<IBusRepository>();
        }

        public BusController(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

        public IEnumerable<Bus> Get()
        {
            return _busRepository.GetAll();
        }

        public Bus Get(Guid id)
        {
            return _busRepository.GetById(id);
        }
    }
}
