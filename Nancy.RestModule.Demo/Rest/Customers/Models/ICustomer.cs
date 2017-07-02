using System;

namespace Nancy.RestModule.Demo.Rest.Customers.Models
{
    public interface ICustomer
    {
        Guid Id { get; }

        string FirstName { get; }

        string LastName { get; }

        int Age { get; }

        DateTime Created { get; }

        void Update(string firstName, string lastName, int? age);
    }
}