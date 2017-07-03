using FluentAssertions;
using Nancy.Testing;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Modules
{
    [TestFixture]
    public class RestModule_when_dispatch
    {
        [SetUp]
        public void TestSetup()
        {
            // Arrange
            var bootstrapper = new DefaultNancyBootstrapper();
            _browser = new Browser(bootstrapper);
        }

        private Browser _browser;

        [Test]
        public void When_get_Then_response_is_returned()
        {
            // Act
            BrowserResponse response = _browser.Get("/test/0", with =>
            {
                with.HttpRequest();
                with.Header("Accept", "application/json");
            });

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.ContentType.Should().Be("application/json");

            var result = response.Body.AsString();
            result.Should().Be("{\"name\":\"1\"}");
        }

        [Test]
        public void When_get_list_Then_list_is_returned()
        {
            // Act
            BrowserResponse response = _browser.Get("/test", with => with.HttpRequest());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.ContentType.Should().Be("application/json");

            var result = response.Body.AsString();
            result.Should().Be("[{\"name\":\"1\"},{\"name\":\"2\"}]");
        }
    }
}