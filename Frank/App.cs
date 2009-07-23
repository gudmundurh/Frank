using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Frank
{
    public class App : FrankApp
    {
        public override void Setup()
        {
            Get("/", r => "Hello world");
            Get("/hello/{name}", r => "Hello there [somehow get name ;)]");
        }
    }

    public abstract class FrankApp
    {
        private readonly RouteCollection _routeCollection = new RouteCollection();

        public abstract void Setup();

        public void Run()
        {
            throw new NotImplementedException();
        }

        //TODO: Implement also Post, Put and Delete
        protected void Get(string url, Func<ViewContext, object> func)
        {
            var route = new Route(url, new FrankRouteHandler(func));
            _routeCollection.Add(route);

            throw new NotImplementedException();
        }
    }

    public class FrankRouteHandler : IRouteHandler
    {
        public FrankRouteHandler(Func<ViewContext, object> func)
        {
            throw new NotImplementedException();
        }

        #region IRouteHandler Members

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}