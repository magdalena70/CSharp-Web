using System;
using System.IO;

namespace BrowseCakes
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html = File.ReadAllText("../htdocs/ByTheCake/browseCakes.html");
            Console.WriteLine(html);

            string inputValue = Environment.GetEnvironmentVariable("QUERY_STRING");
            Console.WriteLine($"<p>{inputValue}</p>");

            string[] cakes = File.ReadAllLines("database.csv");
            string searchFromCakes = inputValue.Split('=')[1];
            
            foreach (var cakeValue in cakes)
            {
                if (cakeValue.ToLower().Contains(searchFromCakes.ToLower()))
                {
                    Console.WriteLine($"<p>{cakeValue}</p>");
                }
            }
        }
    }
}
