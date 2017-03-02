using System.Text;

namespace PizzaMore.App.ViewModels
{
    public class PizzaDetailsViewModel
    {
        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int UpVotes { get; set; }

        public int DownVotes { get; set; }

        public override string ToString()
        {
            StringBuilder bd = new StringBuilder();

            bd.AppendLine("<div>");
            bd.AppendLine("<a class=\"btn btn-danger\" href=\"/menu/index\">All Suggestions</a>");
            bd.AppendLine($"<h3>{this.Title}</h3>");
            bd.AppendLine($"<img src=\"{this.ImageUrl}\" class=\"img img-responsive\" width=\"300px\"/>");
            bd.AppendLine($"<p>{this.Recipe}</p>");
            bd.AppendLine($"<p>Up: {this.UpVotes}</p>");
            bd.AppendLine($"<p>Down: {this.DownVotes}</p>");
            bd.AppendLine("</div>");

            return bd.ToString();
        }
    }
}
