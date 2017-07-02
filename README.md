[![Build status](https://ci.appveyor.com/api/projects/status/0gf5r1lkqub9uou7?svg=true)](https://ci.appveyor.com/project/SRoddis/nancy-restcontroller)

# Nancy.RestModule

Nancy.RestModule is designed to create REST resources in a fast and simple way (with NancyFx). The `RestModule` decouples the `NancyModule` from your self-implemented controller, so the controller can be tested easily. 

Nancy.RestModule can handle `DELETE`, `GET`, `POST` and `PUT` requests and provides a simple JSON.
With the generic request handlers you are able to define your API interface by simple `RequestModels` which are bind automatically from NancyFx.

# Installation

Install via nuget https://www.nuget.org/packages/Nancy.RestModule

```
PM> Install-Package Nancy.RestModule
```

# How to use

1. Create your custom `RestModule` in your NancyFx-Application.
    ```csharp
    public class CustomerModule : RestModule
    {
        public CustomerModule() 
            : base("/customer")
        {
        }
    }
    ```
2. Create your custom `Controller` and register it to the `DIContainer`.
Now the `Controller` can be easily tested by `UnitTests` without `Nancy.Testing`

    ```csharp
    public class CustomerController : ICustomerController
    {
        private readonly ICustomerService _service;
    
        public CustomerController(ICustomerService service) {
            _service = service;
        }
    
        public ResponseModel GetList() {
            IEnumerable<ICustomer> customers = _service.FindAll();
            return customers.CreateResponse();
        }
    
        public ResponseModel Get(GetCustomerRequest customerRequest) {
            ICustomer customer = _service.Find(customerRequest.Id);
            return customer.CreateResponse();
        }
        
        // ... etc.
    }
    ```
3. Inject the controller in the module and define your routes and models.
Now you can define your REST interface without pushing everything in the `NancyModule`.
    
    ```csharp
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
    ```
    

Compile, run and enjoy the simplicity! 


## Demo
In the repository you can find [Nancy.RestController.Demo]( https://github.com/SRoddis/Nancy.RestModule/tree/master/Nancy.Controller.Demo) which is a simple demo to show how to use Nancy.RestModule. 

1. Compile and run the demo application.
2. Now you can [list all customers](http://localhost:53638/customer/) and should get the following response.
    ```json
    [
        {
            "id": "a6617590-ac2f-453e-ad3e-f9f1a409898f",
            "firstName": "Jeff",
            "lastName": "Dunham",
            "age": 56,
            "created": "2017-07-02T18:08:56.7914955Z"
        },
        {
            "id": "c886e841-3946-4f89-a46d-206cb29f407d",
            "firstName": "Lee",
            "lastName": "Evans",
            "age": 53,
            "created": "2017-07-02T18:08:56.7924963Z"
        },
        {
            "id": "748e9266-02fb-445b-8fd1-11ede9093331",
            "firstName": "John",
            "lastName": "Cleese",
            "age": 79,
            "created": "2017-07-02T18:08:56.7924963Z"
        }
    ]
    ```
3. `(Optional)` Change the resource with `PUT` and `POST` 

## Copyright

Copyright © 2017 Sean Roddis

## License

Nancy.RestModule is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to license.txt for more information.