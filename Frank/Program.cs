using System;

namespace Frank
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new App().Run(8080);
            while (true)
                Console.ReadLine(); 
            //Console.WriteLine(new App().Request("/"));
        }
    }
}