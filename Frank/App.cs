using System;
using System.Net;
using System.Web;
using System.Web.Routing;
using HttpServer;
using HttpListener=HttpServer.HttpListener;

namespace Frank
{
    public class App : FrankApp
    {
        public override void Setup()
        {
            Get("/", r => "Hello world");
            Get("/hello/{name}", r => "Hello there " + r["name"]);
        }
    }

    public abstract class FrankApp
    {
        private readonly RouteCollection routes = new RouteCollection();

        public FrankApp()
        {
            routes.RouteExistingFiles = false;
        }

        public abstract void Setup();

        public void Run(int port)
        {
            HttpListener httpListener = HttpListener.Create(IPAddress.Any, port);
            httpListener.RequestReceived += OnRequest;
            httpListener.Start(5);
        }

        
        private void OnRequest(object source, RequestEventArgs args)
        {
            IHttpClientContext context = (IHttpClientContext)source;
            IHttpRequest request = args.Request;

            // Respond is a small convenience function that let's you send one string to the browser.
            // you can also use the Send, SendHeader and SendBody methods to have total control.
            //if (request.Uri.AbsolutePath == "/hello")
            context.Respond("Hi there, what do you want do do with " + request.Uri.AbsolutePath); 

        }
        

        //TODO: Implement also Post, Put and Delete
        protected void Get(string url, Func<RouteValueDictionary, string> action)
        {
            //var route = new Route(url, new RouteValueDictionary(), new RouteValueDictionary {{"httpMethod", "GET"}},
            //                      new FrankRouteHandler(action));
            var route = new Route(url, new FrankRouteHandler(action));
            routes.Add(route);
        }
    }

    public class FrankRouteHandler : IRouteHandler
    {
        private readonly Func<RouteValueDictionary, string> _action;

        public FrankRouteHandler(Func<RouteValueDictionary, string> action)
        {
            _action = action;
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            string result = _action.Invoke(requestContext.RouteData.Values);
            throw new NotImplementedException();
        }

        #endregion
    }
}