using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nancy.RestModule.Extensions;
using Nancy.RestModule.Models;

namespace Nancy.RestModule.Test.Integration.TestModules
{
    public class TestControllerAsync
    {
        private readonly List<TestResponseModel> _data;

        public TestControllerAsync()
        {
            _data = new List<TestResponseModel>
            {
                new TestResponseModel("1"),
                new TestResponseModel("2")
            };
        }

        public Task<ResponseModel> List()
        {
            return Task.FromResult(_data.ToList().CreateResponse());
        }

        public Task<ResponseModel> Get(TestRequestModel model)
        {
            return Task.FromResult(_data[model.Id].CreateResponse());
        }

        public Task<ResponseModel> Post(TestRequestModel model)
        {
            _data.Add(new TestResponseModel(model.Value));

            return Task.FromResult(new ResponseModel {StatusCode = HttpStatusCode.Created});
        }

        public Task<ResponseModel> Put(TestRequestModel model)
        {
            _data[model.Id].Name = model.Value;

            return Task.FromResult(_data[model.Id].CreateResponse());
        }

        public Task<ResponseModel> Delete(TestRequestModel model)
        {
            _data.RemoveAt(model.Id);

            return Task.FromResult(new ResponseModel {StatusCode = HttpStatusCode.NoContent});
        }
    }
}