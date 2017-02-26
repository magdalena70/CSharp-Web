using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using System.Linq;

namespace SimpleMVC.App.Views.Users
{
    public class Profile : IRenderable<UserProfileViewModel>
    {
        public UserProfileViewModel Model { get; set; }

        public string Render()
        {
            string result = $"<h2>User: {Model.Username}, session: {Model.SessionId}</h2>\r\n" +
                "<p><a href=\"/home/index\">Home<a/></p>\r\n" +
                "<form method=\"post\" action=\"profile\">\r\n" +
                "<div>\r\n<input type=\"text\" placeholder=\"Title\" name=\"Title\" required/>\r\n</div>\r\n" +
                "<div>\r\n<input type=\"text\" placeholder=\"Content\" name=\"Content\" required/>\r\n</div>\r\n" +
                $"<div>\r\n<input type=\"hidden\" value=\"{Model.UserId}\" name=\"UserId\" />\r\n</div>\r\n" +
                "<div>\r\n<input type=\"submit\" value=\"Add Note\" />\r\n</div>\r\n" +
                "</form>\r\n" +
                "<h3>List of notes</h3>\r\n" +
                "<ul>\r\n";

            if (Model.Notes.Count() > 0)
            {
                foreach (var note in Model.Notes)
                {
                    result += $"<li><strong>{note.Title}</strong> - {note.Content}</li>\r\n";
                }
            }
            else
            {
                result += "<li><strong>No notes</strong></li>\r\n";
            }

            result += "</ul>";
            return result;
        }
    }
}
