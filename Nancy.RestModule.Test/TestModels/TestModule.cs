namespace Nancy.RestModule.Test.TestModules
{
    public class TestModule : RestModule
    {
        private readonly TestController _controller = new TestController();

        public TestModule() : base("/test")
        {
            GetHandler("/", _controller.List);

            GetHandler<TestRequestModel>("/{id}", _controller.Get);

            PostHandler<TestRequestModel>("/", _controller.Post);

            PutHandler<TestRequestModel>("/{id}", _controller.Put);

            DeleteHandler<TestRequestModel>("/{id}", _controller.Delete);
        }
    }
}