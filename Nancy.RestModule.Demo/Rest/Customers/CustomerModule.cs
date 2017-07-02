using Nancy.RestModule.Demo.Rest.Customers.Requests;

namespace Nancy.RestModule.Demo.Rest.Customers
{
    public class CustomerModule : RestModule
    {
        public CustomerModule(ICustomerController controller) 
            : base("/customer")
        {
            GetHandler("/", controller.GetList);

            GetHandler<GetCustomerRequest>("/{id}", controller.Get);

            PostHandler<PostCustomerRequest>("/", controller.Post);

            PutHandler<PutCustomerRequest>("/{id}", controller.Put);
        }
    }
}