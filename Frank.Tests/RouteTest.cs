using System;
using HttpServer;
using Moq;
using NUnit.Framework;

namespace Frank.Tests
{
    [TestFixture]
    public class RouteTest
    {
        private FrankRouteHandler _routeHandler;

        public void SetUp()
        {
            _routeHandler = new FrankRouteHandler(p => "");
        }

        private static IHttpRequest CreateRequest(string uri, HttpMethod method)
        {
            var mockRequest = new Mock<IHttpRequest>();
            mockRequest.Setup(r => r.Method).Returns(method.ToString());
            mockRequest.Setup(r => r.Uri).Returns(new Uri("http://localhost" + uri));
            return mockRequest.Object;
        }

        [Test]
        public void Basic()
        {
            var route = new Route("/", _routeHandler, HttpMethod.GET);
            Assert.IsNotNull(route.Matches(CreateRequest("/", HttpMethod.GET)));
        }
    }
}