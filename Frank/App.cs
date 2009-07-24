namespace Frank
{
    public class App : FrankApp
    {
        public App()
        {
            Get("/", r => "Hello world");
            Get("/hello/", r => "Hello there visitor requesting " + r.Request.UriPath);
        }
    }
}