using System.Collections.Generic;
using HttpServer;
using HttpServer.HttpModules;
using HttpServer.Sessions;

namespace Frank
{
    internal class FrankHttpModule : HttpModule
    {
        private readonly List<Route> _routes;

        public FrankHttpModule(List<Route> routes)
        {
            _routes = routes;
        }

        public override bool Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
        {
            foreach (Route route in _routes)
            {
                if (route.Matches(request))
                {
                    route.RouteHandler.Process(request, response, session);
                    return true;
                }
            }
            return false;
        }
    }
}