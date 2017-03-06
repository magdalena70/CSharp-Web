using System;
using System.Text;

namespace SoftUniStore.App.ViewModels
{
    public class GameDetailsViewModel
    {
        public int GameId { get; set; }

        public string Title { get; set; }

        public string Trailer { get; set; }

        public int Size { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public override string ToString()
        {
            StringBuilder bd = new StringBuilder();

            bd.AppendLine($"<h1 class=\"display-3\">{this.Title}</h1>");
            bd.AppendLine($"<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/{this.Trailer}\" frameborder=\"0\" allowfullscreen></iframe>");
            bd.AppendLine($"<p>{this.Description}</p>");
            bd.AppendLine($"<p><strong>Price</strong> - {this.Price} &euro;</p>");
            bd.AppendLine($"<p><strong>Size</strong> - {this.Size} GB</p>");
            bd.AppendLine($"<p><strong>Release Date</strong> - {this.ReleaseDate}</p>");
            bd.AppendLine($"<a class=\"btn btn-outline-primary\" name=\"back\" href=\"/home/index\">Back</a>\r\n<br/>");
            bd.AppendLine($"<form method=\"post\">");
            bd.AppendLine($"<input type=\"number\" value=\"{this.GameId}\" name=\"GameId\" hidden=\"hidden\" />\r\n<br/>");
            bd.AppendLine($"<input type=\"submit\" class=\"btn btn-success\" value=\"Buy\" />\r\n</form>");

            return bd.ToString();
        }
    }
}
