using System;

namespace Nancy.RestModule.Demo.Rest.Customers.Requests
{
    public class PutCustomerRequest
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}