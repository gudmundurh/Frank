using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using HttpServer;
using HttpServer.HttpModules;
using HttpServer.Sessions;

namespace Frank
{
    public abstract class FrankApp : HttpModule
    {
        private readonly List<Route> _routes = new List<Route>();

        public void Run(int port)
        {
            var httpServer = new HttpServer.HttpServer {LogWriter = new ConsoleLogWriter()};
            httpServer.Add(this);
            httpServer.Start(IPAddress.Any, port);
        }

        public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
        {
            foreach (Route route in _routes)
            {
                if (request.Method != route.Method.ToString()) continue;

                RouteValues routeValues = route.Matches(request);

                if (routeValues == null) continue;

                route.RouteHandler.Process(routeValues, request, response, session);
                return true;
            }
            return false;
        }
        
        protected void Get(string routeUrl, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeUrl, new FrankRouteHandler(action), HttpMethod.GET));
        }

        protected void Get(Regex routeRegex, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeRegex, new FrankRouteHandler(action), HttpMethod.GET));
        }

        protected void Post(string routeUrl, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeUrl, new FrankRouteHandler(action), HttpMethod.POST));
        }

        protected void Post(Regex routeRegex, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeRegex, new FrankRouteHandler(action), HttpMethod.POST));
        }

        protected void Put(string routeUrl, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeUrl, new FrankRouteHandler(action), HttpMethod.PUT));
        }

        protected void Put(Regex routeRegex, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeRegex, new FrankRouteHandler(action), HttpMethod.PUT));
        }

        protected void Delete(string routeUrl, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeUrl, new FrankRouteHandler(action), HttpMethod.DELETE));
        }

        protected void Delete(Regex routeRegex, Func<ActionParameters, string> action)
        {
            _routes.Add(new Route(routeRegex, new FrankRouteHandler(action), HttpMethod.DELETE));
        }    
    
    }
}