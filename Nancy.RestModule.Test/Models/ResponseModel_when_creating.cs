using FluentAssertions;
using Nancy.RestModule.Models;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Models
{
    [TestFixture]
    public class ResponseModel_When_creating
    {
        [Test]
        public void Then_is_ResponseModel()
        {
            // Arrange
            var response = new ResponseModel();

            // Assert
            response.Should().BeOfType<ResponseModel>();
        }

        [Test]
        public void Then_model_is_null()
        {
            // Arrange
            var response = new ResponseModel();

            // Assert
            response.Model.Should().BeNull();
        }

        [Test]
        public void When_model_is_generic_Then_ResponseModel_should_contain_generic_type()
        {
            // Arrange
            var response = new ResponseModelTestType() {Model = new TestType()};

            // Act
            var model = response.Model;

            // Assert
            model.Should().BeOfType<TestType>();
        }

        private class ResponseModelTestType : ResponseModel<TestType>
        {
        }

        private class TestType
        {
        }
    }
}