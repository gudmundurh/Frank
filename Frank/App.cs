using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

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

        public abstract void Setup();

        public void Run()
        {
            throw new NotImplementedException();
        }

        public string Request(string url)
        {
            var mockHttpContextBase = new Mock<HttpContextBase>();
            mockHttpContextBase.Setup(m => m.Request.AppRelativeCurrentExecutionFilePath).Returns(url);
            RouteData routeData = routes.GetRouteData(mockHttpContextBase.Object);

            string output = routeData + "\n";
            foreach (var key in routeData.Values.Keys)
                output += string.Format("{0} = {1}\n", key, routeData.Values[key]);

            return output;
        }

        //TODO: Implement also Post, Put and Delete
        protected void Get(string url, Func<RouteValueDictionary, string> action)
        {
            var route = new Route(url, new RouteValueDictionary(), new RouteValueDictionary {{"httpMethod", "GET"}},
                                  new FrankRouteHandler(action));
            routes.Add(route);
        }
    }

    public class FrankRouteHandler : IRouteHandler
    {
        private Func<RouteValueDictionary, string> _action;

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