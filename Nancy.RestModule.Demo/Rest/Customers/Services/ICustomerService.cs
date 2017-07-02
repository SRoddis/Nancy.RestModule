using System;
using System.Collections.Generic;
using Nancy.RestModule.Demo.Rest.Customers.Models;

namespace Nancy.RestModule.Demo.Rest.Customers.Services
{
    public interface ICustomerService
    {
        IEnumerable<ICustomer> FindAll();

        ICustomer Find(Guid id);

        void Create(string firstName, string lastName, int age);

        void Update(Guid id, string firstName, string lastName, int? age);

        void Delete(Guid id);
    }
}