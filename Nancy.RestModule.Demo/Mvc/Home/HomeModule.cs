namespace Nancy.RestModule.Demo.Mvc.Home
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = context => "Hallo Nancy.RestModule Demo! You can list all customers with '/customer'. :)";
        }
    }
}