using SoftUniStore.App.Models;
using System.Collections.Generic;
using System.Text;

namespace SoftUniStore.App.ViewModels
{
    public class HomeGamesViewModel
    {
        public ICollection<GameViewModel> AllGames { get; set; }

        public override string ToString()
        {
            StringBuilder bd = new StringBuilder();
            if (this.AllGames.Count == 0)
            {
                bd.AppendLine("<div class=\"card\">\r\n<div class=\"card-block text-center\">\r\n");
                bd.AppendLine("<h3>No games</h3>\r\n");
                bd.AppendLine("</div>\r\n</div>");
            }
            else
            {
                int index = 0;
                bd.AppendLine("<div class=\"card-group\">");

                foreach (var game in this.AllGames)
                {
                    if (game.Description.Length > 300)
                    {
                        game.Description = game.Description.Substring(0, 300);
                    }

                    bd.AppendLine("<div class=\"card col-4 thumbnail\">");
                    bd.AppendLine($"<img class=\"card-image-top img-fluid img-thumbnail\" src=\"{game.ImageThumbnail}\">");
                    bd.AppendLine("<div class=\"card-block\">");
                    bd.AppendLine($"<h4 class=\"card-title\">{ game.Title}</h4>");
                    bd.AppendLine($"<p class=\"card-text\"><strong>Price</strong> - {game.Price} €</p>");
                    bd.AppendLine($"<p class=\"card-text\"><strong>Size</strong> - {game.Size} GB</p>");
                    bd.AppendLine($"<p class=\"card-text\" >{game.Description}</p>\r\n</div>");
                    bd.AppendLine("<div class=\"card-footer\">");
                    bd.AppendLine($"<a class=\"card-button btn btn-outline-primary\" name=\"info\" href=\"/game/details?gameId={game.Id}\">Info</a></div>\r\n</div>\r\n");
                    index++;
                    if (index % 3 == 0)
                    {
                        bd.AppendLine("<div class=\"card-group\">");
                    }

                }

                bd.AppendLine("</div>");
            }
           
            return bd.ToString();
        }
    }
}
