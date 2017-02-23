using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using System;
using System.Collections.Generic;

namespace SimpleMVC.App.Views.Users
{
    public class All : IRenderable<IEnumerable<AllUsernamesViewModel>>
    {
        public IEnumerable<AllUsernamesViewModel> Model { get; set; }

        public string Render()
        {
            Console.WriteLine("render All");
            string result = "<h2>All Users</h3>\r\n" +
                "<p><a href=\"/home/index\">Home<a/></p>\r\n" +
                "<ul>\r\n";
            foreach (var user in Model)
            {
                result += $"<li>\r\n<a href=\"profile?id={user.UserId}\">{user.Username}</a>\r\n</li>\r\n";
            }

            result += "</ul>";
            return result;
        }
    }
}
