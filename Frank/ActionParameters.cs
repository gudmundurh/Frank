using HttpServer;
using HttpServer.Sessions;

namespace Frank
{
    public class ActionParameters
    {
        public ActionParameters(IHttpRequest request, IHttpResponse response, IHttpSession session)
        {
            Request = request;
            Response = response;
            Session = session;
        }

        public IHttpRequest Request { get; private set; }
        public IHttpResponse Response { get; private set; }
        public IHttpSession Session { get; private set; }
    }
}