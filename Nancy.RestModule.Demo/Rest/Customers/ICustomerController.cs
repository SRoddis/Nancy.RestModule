using Nancy.RestModule.Demo.Rest.Customers.Requests;
using Nancy.RestModule.Models;

namespace Nancy.RestModule.Demo.Rest.Customers
{
    public interface ICustomerController
    {
        ResponseModel GetList();

        ResponseModel Get(GetCustomerRequest customerRequest);

        ResponseModel Post(PostCustomerRequest request);

        ResponseModel Put(PutCustomerRequest request);
    }
}