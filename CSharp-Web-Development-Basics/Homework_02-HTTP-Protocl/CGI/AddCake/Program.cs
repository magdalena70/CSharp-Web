using System;
using System.IO;
using System.Net;

namespace AddCake
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-type: text/html\r\n");
            string html = File.ReadAllText("../htdocs/ByTheCake/addCake.html");
            Console.WriteLine(html);
            string[] newCake = Console.ReadLine().Split('&');
            Console.WriteLine("\r\n<section id=\"newCake-info\">\r\n");
            foreach (var item in newCake)
            {
                string itemName = item.Split('=')[0];
                string itemValue = item.Split('=')[1];
                if (String.IsNullOrEmpty(itemValue))
                {
                    string errorMsg = $"Invalid input! {itemName} can not by empty!";
                    Console.WriteLine($"<p id=\"errorMsg\">{errorMsg}</p>\r\n");
                    break;
                }
                else
                {
                    Console.WriteLine($"<p>\r\n<em>{itemName}</em>\r\n = {WebUtility.HtmlEncode(itemValue)}</p>\r\n");
                    File.AppendAllText("database.csv", itemValue + ",");
                }

            }
            File.AppendAllText("database.csv", "\n");
            Console.WriteLine("</section>");
        }
    }
}
