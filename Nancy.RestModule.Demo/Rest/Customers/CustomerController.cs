using System.Collections.Generic;
using Nancy.RestModule.Demo.Rest.Customers.Models;
using Nancy.RestModule.Demo.Rest.Customers.Requests;
using Nancy.RestModule.Demo.Rest.Customers.Services;
using Nancy.RestModule.Extensions;
using Nancy.RestModule.Models;

namespace Nancy.RestModule.Demo.Rest.Customers
{
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        public ResponseModel GetList()
        {
            IEnumerable<ICustomer> customers = _service.FindAll();

            return customers.CreateResponse();
        }

        public ResponseModel Get(GetCustomerRequest customerRequest)
        {
            ICustomer customer = _service.Find(customerRequest.Id);

            return customer.CreateResponse();
        }

        public ResponseModel Post(PostCustomerRequest request)
        {
            _service.Create(request.FirstName, request.LastName, request.Age);

            return new ResponseModel {StatusCode = HttpStatusCode.Created };
        }

        public ResponseModel Put(PutCustomerRequest request)
        {
            _service.Update(request.Id, request.FirstName, request.LastName, request.Age);

            return new ResponseModel { StatusCode = HttpStatusCode.OK };
        }
    }
}