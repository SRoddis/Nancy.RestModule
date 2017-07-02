using System;

namespace Nancy.RestModule.Demo.Rest.Customers.Models
{
    internal class Customer : ICustomer
    {
        public Customer(string fristName, string lastName, int age)
        {
            Id = Guid.NewGuid();
            Created = DateTime.UtcNow;

            FirstName = fristName;
            LastName = lastName;
            Age = age;
        }

        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public int Age { get; private set; }

        public DateTime Created { get; private set; }

        public void Update(string firstName, string lastName, int? age)
        {
            FirstName = firstName ?? FirstName;
            LastName = lastName ?? LastName;
            Age = age ?? Age;
        }
    }
}