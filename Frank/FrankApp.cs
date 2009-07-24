using System;
using System.Collections.Generic;
using System.Net;

namespace Frank
{
    public abstract class FrankApp
    {
        private readonly List<Route> routes = new List<Route>();

        public void Run(int port)
        {
            var httpServer = new HttpServer.HttpServer();
            httpServer.Add(new FrankHttpModule(routes));
            httpServer.Start(IPAddress.Any, port);
        }

        //TODO: Implement also Post, Put and Delete
        protected void Get(string url, Func<ActionParameters, string> action)
        {
            routes.Add(new Route(url, new FrankRouteHandler(action)));
        }
    }
}