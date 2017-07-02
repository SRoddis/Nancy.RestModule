namespace Nancy.RestModule.Test.TestModules
{
    public class TestModule : RestModule
    {
        public TestModule() : base("/test")
        {
            var controller = new TestController();

            GetHandler("/", controller.List);

            GetHandler<TestRequestModel>("/{id}", controller.Get);

            PostHandler<TestRequestModel>("/", controller.Post);

            PutHandler<TestRequestModel>("/{id}", controller.Put);

            PutHandler<TestRequestModel>("/{id}", controller.Put);
        }

        protected override void DoValidate<TRequest>(TRequest model)
        {
            // No validation
        }
    }
}