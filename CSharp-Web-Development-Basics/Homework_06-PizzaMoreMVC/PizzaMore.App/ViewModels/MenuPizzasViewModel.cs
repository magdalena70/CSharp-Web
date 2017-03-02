using PizzaMore.App.Models;
using System.Collections.Generic;
using System.Text;

namespace PizzaMore.App.ViewModels
{
    public class MenuPizzasViewModel
    {
        public ICollection<Pizza> PizzaSuggestions { get; set; }

        public override string ToString()
        {
            StringBuilder bd = new StringBuilder();
            foreach (var pizza in this.PizzaSuggestions)
            {
                bd.AppendLine("<div class=\"card\">");
                bd.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                bd.AppendLine("<div class=\"card-block\">");
                bd.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                bd.AppendLine($"<p class=\"card-text\"><a href=\"/menu/details?pizzaId={pizza.Id}\">Recipe</a></p>");
                bd.AppendLine("<form method=\"POST\">");
                bd.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"Vote\" value=\"Up\">Up</label><span> - {pizza.UpVotes}</span></div>");
                bd.AppendLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"Vote\" value=\"Down\">Down</label><span> - {pizza.DownVotes}</span></div>");
                bd.AppendLine($"<input type=\"hidden\" name=\"PizzaId\" value=\"{pizza.Id}\" />");
                bd.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                bd.AppendLine("</form>");
                bd.AppendLine("</div>");
                bd.AppendLine("</div>");
            }
            return bd.ToString();
        }
    }
}
