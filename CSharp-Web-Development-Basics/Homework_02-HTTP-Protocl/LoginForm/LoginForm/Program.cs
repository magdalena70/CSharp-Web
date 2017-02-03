using System;
using System.IO;
using System.Net;

namespace LoginForm
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Content-Type: text/html\r\n");
            string html = File.ReadAllText("../htdocs/LoginForm/loginForm.html");
            Console.WriteLine(html);

            string[] inputContent = Console.ReadLine().Split('&');
            Console.WriteLine("\r\n<section id=\"user-info\">\r\n");

            string user = "";
            foreach (var item in inputContent)
            {
                string key = item.Split('=')[0];
                string itemValue = item.Split('=')[1];
                if (String.IsNullOrEmpty(itemValue))
                {
                    string errorMsg = $"Invalid input! {key} can not by empty!";
                    Console.WriteLine($"<p id=\"errorMsg\">{errorMsg}</p>\r\n");
                    break;
                }
                else
                {
                    user += WebUtility.HtmlEncode(itemValue) + ";";
                }
            }

            Console.WriteLine($"<p>Hi {user.Split(';')[0]}, your password is {user.Split(';')[1]}</p>\r\n");
            Console.WriteLine("</section>");
        }
    }
}
