using FluentAssertions;
using Nancy.RestModule.Exceptions;
using Nancy.Validation;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Unit.Exceptions
{
    [TestFixture]
    public class ApiValidationException_when_creating
    {
        [Test]
        public void Then_is_created()
        {
            // Arrange
            var modelResult = new ModelValidationResult();

            // Act
            var exception = new ApiValidationException(modelResult);

            // Assert
            exception.ModelValidationResult().Should().Be(modelResult);
        }
    }
}