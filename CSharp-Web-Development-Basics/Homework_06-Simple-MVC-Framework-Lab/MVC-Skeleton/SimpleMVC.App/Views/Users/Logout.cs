using System;
using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Users
{
    public class Logout : IRenderable
    {
        public string Render()
        {
            return "<form method=\"post\" ><button type=\"submit\">Logout</button></form>" +
                "<p><a href=\"/home/index\">Home<a/></p>\r\n";
        }
    }
}
