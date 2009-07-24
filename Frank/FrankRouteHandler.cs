using System;
using System.IO;
using HttpServer;
using HttpServer.Sessions;

namespace Frank
{
    internal class FrankRouteHandler
    {
        private readonly Func<ActionParameters, string> _action;

        public FrankRouteHandler(Func<ActionParameters, string> action)
        {
            _action = action;
        }

        public void Process(IHttpRequest request, IHttpResponse response, IHttpSession session)
        {
            string output = _action.Invoke(new ActionParameters(request, response, session));
            var writer = new StreamWriter(response.Body);
            writer.Write(output);
            writer.Flush();
        }
    }
}