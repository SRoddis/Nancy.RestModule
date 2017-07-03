using System;
using FluentAssertions;
using Nancy.RestModule.Exceptions;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Unit.Exceptions
{
    [TestFixture]
    public class ModelBindingFailedException_when_creating
    {
        [Test]
        public void Then_is_created()
        {
            // Arrange Act
            var exception = new ModelBindingFailedException();

            // Assert
            exception.Should().BeOfType<ModelBindingFailedException>();
        }

        [Test]
        public void When_set_message_Then_contains_message()
        {
            // Arrange Act
            var exception = new ModelBindingFailedException("test");

            // Assert
            exception.Message.Should().Be("test");
        }

        [Test]
        public void When_set_prev_exception_Then_contains_exception()
        {
            // Arrange
            var prev = new Exception();

            // Act
            var exception = new ModelBindingFailedException("test", prev);

            // Assert
            exception.InnerException.Should().Be(prev);
        }
    }
}