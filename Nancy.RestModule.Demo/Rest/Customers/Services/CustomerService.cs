using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.RestModule.Demo.Rest.Customers.Models;

namespace Nancy.RestModule.Demo.Rest.Customers.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<ICustomer> _customerDataBase = new List<ICustomer>
        {
            new Customer("Jeff", "Dunham", 56),
            new Customer("Lee", "Evans", 53),
            new Customer("John", "Cleese", 79)
        };

        public IEnumerable<ICustomer> FindAll()
        {
            return _customerDataBase;
        }

        public ICustomer Find(Guid id)
        {
            return _customerDataBase.SingleOrDefault(c => c.Id == id);
        }

        public void Create(string firstName, string lastName, int age)
        {
            var customer = new Customer(firstName, lastName, age);
            _customerDataBase.Add(customer);
        }

        public void Update(Guid id, string firstName, string lastName, int? age)
        {
            ICustomer customer = _customerDataBase.FirstOrDefault(c => c.Id == id);

            if (customer == null) return;

            customer.Update(firstName, lastName, age);
        }

        public void Delete(Guid id)
        {
            ICustomer customer = _customerDataBase.Single(c => c.Id == id);
            _customerDataBase.Remove(customer);
        }
    }
}