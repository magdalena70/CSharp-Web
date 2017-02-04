using System;
using System.IO;

namespace SendEmail
{
    class Program
    {
        static void Main()
        {
            string loginHtml = File.ReadAllText("../htdocs/SendEmail/login.html");
            string sendEmailHtml = File.ReadAllText("../htdocs/SendEmail/sendEmail.html");
            string validUsername = "suAdmin";
            string validPass = "aDmInPw17";

            Console.WriteLine("Content-Type: text/html\r\n");
            string method = Environment.GetEnvironmentVariable("REQUEST_METHOD").ToLower();
            //Console.WriteLine(method);
            if (method == "get")
            {
                Console.WriteLine(loginHtml);
            }
            else if (method == "post")
            {
                string[] inputContent = Console.ReadLine().Split('&');
                if (inputContent[0].Split('=')[0] == "Username" & inputContent[1].Split('=')[0] == "Password")
                {
                    string username = inputContent[0].Split('=')[1];
                    string pass = inputContent[1].Split('=')[1];
                    if (username == validUsername & pass == validPass)
                    {
                        Console.WriteLine(sendEmailHtml);
                    }
                    else
                    {
                        Console.WriteLine(loginHtml);
                        Console.WriteLine("<p>Invalid username or password</p>");
                    }
                }     
            }    
        }
    }
}
