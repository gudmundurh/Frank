using System.Collections.Generic;
using System.Text.RegularExpressions;
using HttpServer;

namespace Frank
{
    internal class Route
    {
        private readonly List<string> _parameters = new List<string>();
        private readonly Regex _routeRegex;

        public Route(string routeUrl, FrankRouteHandler routeHandler, HttpMethod method)
        {
            string regex = new Regex(@"{(\w+)}").Replace(routeUrl, m => FormatRouteParameter(m.Groups[1].Value));
            _routeRegex = new Regex("^" + regex + "$");
            RouteHandler = routeHandler;
            Method = method;
        }

        public Route(Regex routeRegex, FrankRouteHandler routeHandler, HttpMethod method)
        {
            _routeRegex = routeRegex;
            RouteHandler = routeHandler;
            Method = method;
        }

        public HttpMethod Method { get; private set; }

        public FrankRouteHandler RouteHandler { get; private set; }

        private string FormatRouteParameter(string name)
        {
            _parameters.Add(name);
            return string.Format("(?<{0}>.+)", name);
        }

        public RouteValues Matches(IHttpRequest request)
        {
            Match match = _routeRegex.Match(request.Uri.AbsolutePath);
            return match.Success ? new RouteValues(_parameters, match) : null;
        }
    }
}