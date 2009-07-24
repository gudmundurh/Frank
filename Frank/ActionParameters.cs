using HttpServer;
using HttpServer.Sessions;

namespace Frank
{
    public class ActionParameters
    {
        public ActionParameters(RouteValues routeValues, IHttpRequest request, IHttpResponse response,
                                IHttpSession session)
        {
            RouteValues = routeValues;
            Request = request;
            Response = response;
            Session = session;
        }

        public string this[string key]
        {
            get { return RouteValues[key]; }
        }

        private RouteValues RouteValues { get; set; }
        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }
        public IHttpSession Session { get; private set; }
    }
}