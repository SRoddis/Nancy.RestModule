namespace Nancy.RestModule.Test.Integration.TestModules
{
    public class TestModuleAsync : RestModuleAsync
    {
        private readonly TestControllerAsync _controller = new TestControllerAsync();

        public TestModuleAsync()
            : base("/testAsync")
        {
            GetHandler("/", _controller.List);

            GetHandler<TestRequestModel>("/{id}", _controller.Get);

            PostHandler<TestRequestModel>("/", _controller.Post);

            PutHandler<TestRequestModel>("/{id}", _controller.Put);

            DeleteHandler<TestRequestModel>("/{id}", _controller.Delete);
        }

        protected override void DoValidate<TRequest>(TRequest model)
        {
            // No validation
        }
    }
}