Frank is a Sinatra-inspired micro-webframework.

A very basic example:

	public class App : FrankApp
	{
		public App()
		{
			Get("/", r => "Hello world");
			Get("/hello/", r => "Hello there visitor requesting " + r.Request.UriPath);
		}
		
		public static void Main(string[] args) 
		{
			new App().Run(8080);
		}
	}
