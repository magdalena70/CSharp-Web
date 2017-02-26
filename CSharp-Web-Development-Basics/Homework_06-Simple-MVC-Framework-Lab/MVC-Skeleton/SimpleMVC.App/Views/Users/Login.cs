using System;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            return "<h2>Login</h2>\r\n" +
               "<p><a href=\"/home/index\">Home<a/></p>\r\n" +
               "<form method=\"post\" action=\"login\">\r\n" +
               "<div>\r\n<input type=\"text\" name=\"Username\" placeholder=\"Username\" required/>\r\n</div>\r\n" +
               "<div>\r\n<input type=\"password\" name=\"Password\" placeholder=\"Password\" required/>\r\n</div>\r\n" +
               "<input type=\"submit\" value=\"Login\"/>\r\n" +
               "</form>";
        }
    }
}
