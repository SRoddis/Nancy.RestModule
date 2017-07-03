[![Build status](https://ci.appveyor.com/api/projects/status/8lbhpmgq03y31e62?svg=true)](https://ci.appveyor.com/project/SRoddis/nancy-restmodule)

# Nancy.RestModule

Nancy.RestModule is designed to create REST resources in a fast and simple way with NancyFx. The `RestModule` decouples the `NancyModule` from your self-implemented controller, so the controller can be tested easily. 

Nancy.RestModule can handle `DELETE`, `GET`, `POST` and `PUT` requests and provides a simple JSON.
With the generic request handlers you are able to define your API interface by simple `RequestModels` which are bind automatically from NancyFx.

# Installation

Install via nuget https://www.nuget.org/packages/Nancy.RestModule

```
PM> Install-Package Nancy.RestModule
```

# How to use

1. Create your `RestModule` in your NancyFx-Application.
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
Now the `Controller` can be easily tested with `UnitTests` without `Nancy.Testing`

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
In the repository you can find [Nancy.RestModule.Demo]( https://github.com/SRoddis/Nancy.RestModule/tree/master/Nancy.RestModule.Demo) which is a simple demo to show how to use Nancy.RestModule. 

1. Compile and run the demo application.
2. Now you can [list all customers](http://localhost:53638/customer/) and should get the following response.
    ```json
    [
        {
            "id": <Guid>,
            "firstName": "Jeff",
            "lastName": "Dunham",
            "age": 56,
            "created": <current datetime>
        },
        {
            "id": <Guid>,
            "firstName": "Lee",
            "lastName": "Evans",
            "age": 53,
            "created": <current datetime>
        },
        {
            "id": <Guid>,
            "firstName": "John",
            "lastName": "Cleese",
            "age": 79,
            "created": <current datetime>
        }
    ]
    ```
3. `(Optional)` Change the resource with `PUT` and `POST` 

## Copyright

Copyright © 2017 Sean Roddis

## License

Nancy.RestModule is licensed under [MIT](http://www.opensource.org/licenses/mit-license.php "Read more about the MIT license form"). Refer to license.txt for more information.
