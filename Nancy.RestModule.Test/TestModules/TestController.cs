using System.Collections.Generic;
using System.Linq;
using Nancy.RestModule.Extensions;
using Nancy.RestModule.Models;

namespace Nancy.RestModule.Test.TestModules
{
    public class TestController
    {
        private readonly List<TestResponseModel> _data;

        public TestController()
        {
            _data = new List<TestResponseModel>
            {
                new TestResponseModel("1"),
                new TestResponseModel("2")
            };
        }

        public ResponseModel List()
        {
            return _data.ToList().CreateResponse();
        }

        public ResponseModel Get(TestRequestModel model)
        {
            return _data[model.Id].CreateResponse();
        }

        public ResponseModel Post(TestRequestModel model)
        {
            _data.Add(new TestResponseModel(model.Value));

            return new ResponseModel {StatusCode = HttpStatusCode.Created};
        }

        public ResponseModel Put(TestRequestModel model)
        {
            _data[model.Id].Name = model.Value;

            return _data[model.Id].CreateResponse();
        }

        public ResponseModel Delete(TestRequestModel model)
        {
            _data.RemoveAt(model.Id);

            return new ResponseModel {StatusCode = HttpStatusCode.NoContent};
        }
    }
}