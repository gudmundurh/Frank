using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Frank
{
    internal class App : FrankApp
    {
        public App()
        {
            Get("/", r => "I did it my way");
            Get(new Regex("^/a+$"), r => "a+ request");
            Get("/hello/", r => "Hello there visitor requesting " + r.Request.UriPath);
            Get("/hello/{name}", r => "Hello there " + r["name"]);
            Get("/{action}/{name}", r =>
                                        {
                                            if (r["action"] == "shutdown")
                                                return "That I can not do";
                                            return string.Format("You want me to do {0}, <em>{1}</em>?", r["action"], r["name"]);
                                        });

            Get("/counter", r =>
                                {
                                    int counter = r.Store.Get<int>("counter");
                                    r.Store["counter"] = counter++;
                                    return counter.ToString();
                                });

            Get("/search/",
                r =>
                @"<form method=""post"" action="".""><input type=""text"" name=""q""> 
                <input type=""submit"" value=""Search""></form>");
            Post("/search/", r => "You searched for " + r.Request.Param["q"]);
        }

        private static void Main(string[] args)
        {
            new App().Run(8081);
            while (true)
                Console.ReadLine();
        }
    }
}