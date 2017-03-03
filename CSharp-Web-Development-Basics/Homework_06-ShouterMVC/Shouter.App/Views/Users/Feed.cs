using System.IO;
using Shouter.App.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Text;
using Shouter.App.Helper;

namespace Shouter.App.Views.Users
{
    public class Feed : IRenderable<FeedViewModel>
    {
        public FeedViewModel Model { get; set; }

        public string Render()
        {
            string htmlFile = File.ReadAllText("../../Content/feed-signed.html");
            StringBuilder bd = new StringBuilder();
            foreach (var shout in Model.AllShouts)
            {
                bd.AppendLine("<div class=\"thumbnail\">");
                bd.AppendLine($"<h4><strong><a href=\"/users/profile?userId={shout.Author.Id}\">{shout.Author.Username}</a><strong><small> {FeedHelper.CalculateTimeSincePost(shout.PostedOn)}</small></h4>");
                bd.AppendLine($"<p>{shout.Content}</p></div>");
            }
            htmlFile = htmlFile.Replace("##feed##", bd.ToString());
            return htmlFile;
        }
    }
}
