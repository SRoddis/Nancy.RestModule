using Autofac;
using Nancy.Bootstrappers.Autofac;
using Nancy.RestModule.Demo.Rest.Customers;
using Nancy.RestModule.Demo.Rest.Customers.Services;

namespace Nancy.RestModule.Demo
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            container.Update(builder => builder.RegisterType<CustomerController>().As<ICustomerController>().SingleInstance());
            container.Update(builder => builder.RegisterType<CustomerService>().As<ICustomerService>().SingleInstance());
        }
    }
}