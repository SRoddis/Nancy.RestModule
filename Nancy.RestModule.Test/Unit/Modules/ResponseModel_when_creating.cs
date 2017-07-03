using FluentAssertions;
using Nancy.RestModule.Test.TestModels;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Unit.Modules
{
    [TestFixture]
    public class Module_when_creating
    {
        [Test]
        public void Then_is_created()
        {
            // Arrange
            var module = new TestModule();

            // Assert
            module.Should().BeOfType<TestModule>();
        }
    }
}