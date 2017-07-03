﻿namespace Nancy.RestModule.Test.Integration.TestModules
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

        protected override void DoValidate<TRequest>(TRequest model)
        {
            // No validation
        }
    }
}