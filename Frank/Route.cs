using HttpServer;

namespace Frank
{
    internal class Route
    {
        private readonly string _routeUrl;

        public Route(string routeUrl, FrankRouteHandler routeHandler)
        {
            _routeUrl = routeUrl;
            RouteHandler = routeHandler;
        }

        public FrankRouteHandler RouteHandler { get; private set; }

        public bool Matches(IHttpRequest request)
        {
            return request.UriPath == _routeUrl;
        }
    }
}