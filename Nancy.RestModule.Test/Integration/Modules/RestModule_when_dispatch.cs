using FluentAssertions;
using Nancy.Testing;
using NUnit.Framework;

namespace Nancy.RestModule.Test.Integration.Modules
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
        public void When_delete_Then_response_is_NoContent()
        {
            // Act
            BrowserResponse post = _browser.Delete("/test/1", with => with.HttpRequest());

            // Assert
            post.StatusCode.Should().Be(HttpStatusCode.NoContent);
            post.ContentType.Should().Be("application/json");
        }

        [Test]
        public void When_put_Then_response_is_OK()
        {
            // Act
            BrowserResponse post = _browser.Put("/test/1", with =>
            {
                with.HttpRequest();
                with.Query("value", "3");
            });

            // Assert
            post.StatusCode.Should().Be(HttpStatusCode.OK);
            post.ContentType.Should().Be("application/json");
        }

        [Test]
        public void When_post_Then_response_is_Created()
        {
            // Act
            BrowserResponse post = _browser.Post("/test", with =>
            {
                with.HttpRequest();
                with.Query("value", "3");
            });

            // Assert
            post.StatusCode.Should().Be(HttpStatusCode.Created);
            post.ContentType.Should().Be("application/json");
        }

        [Test]
        public void When_get_Then_response_is_OK()
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
        }

        [Test]
        public void When_get_list_Then_response_is_OK()
        {
            // Act
            BrowserResponse response = _browser.Get("/test", with => with.HttpRequest());

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.ContentType.Should().Be("application/json");
        }
    }
}