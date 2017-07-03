using FluentAssertions;
using Nancy.RestModule.Extensions;
using Nancy.RestModule.Models;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Unit.Extensions
{
    [TestFixture]
    public class ResponseModelExtension_when_create_response
    {
        [Test]
        public void When_type_is_object_Then_model_should_be_object()
        {
            // Arrange
            var obj = new object();

            // Act
            object model = obj.CreateResponse().Model;

            // Assert
            model.Should().BeOfType<object>();
        }

        [Test]
        public void When_parameter_is_default_Then_response_is_HttpStatusCode_ok()
        {
            // Arrange
            var obj = new object();

            // Act
            var result = obj.CreateResponse().StatusCode;

            // Assert
            result.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void When_type_is_object_Then_response_can_be_created()
        {
            // Arrange
            var obj = new object();

            // Act
            ResponseModel result = obj.CreateResponse();

            // Assert
            result.Should().BeOfType<ResponseModel>();
        }
    }
}