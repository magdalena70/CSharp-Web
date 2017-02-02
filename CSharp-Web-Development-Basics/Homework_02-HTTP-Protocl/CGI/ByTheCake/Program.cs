using System;
using System.IO;

namespace CGI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html = File.ReadAllText("../htdocs/ByTheCake/byTheCake.html");
            Console.WriteLine(html);
        }
    }
}
