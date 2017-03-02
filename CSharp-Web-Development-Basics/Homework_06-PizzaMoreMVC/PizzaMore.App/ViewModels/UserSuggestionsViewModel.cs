using PizzaMore.App.Models;
using System.Collections.Generic;
using System.Text;

namespace PizzaMore.App.ViewModels
{
    public class UserSuggestionsViewModel
    {
        public IEnumerable<Pizza> UserSuggestions { get; set; }

        public override string ToString()
        {
            StringBuilder bd = new StringBuilder();
            foreach (var pizza in this.UserSuggestions)
            {
                bd.AppendLine("<div class=\"card\">");
                bd.AppendLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                bd.AppendLine("<div class=\"card-block\">");
                bd.AppendLine($"<h4 class=\"card-title\">{pizza.Title}</h4>");
                bd.AppendLine($"<p class=\"card-text\"><a href=\"/menu/details?pizzaId={pizza.Id}\">Recipe</a></p>");
                bd.AppendLine("<form method=\"POST\">");
                bd.AppendLine($"<input type=\"hidden\" name=\"PizzaId\" value=\"{pizza.Id}\" />");
                bd.AppendLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"X\" />");
                bd.AppendLine("</form>");
                bd.AppendLine("</div>");
                bd.AppendLine("</div>");
            }
            return bd.ToString();
        }
    }
}
