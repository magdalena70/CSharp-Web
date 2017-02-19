using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using SharpStore.Models;

namespace SharpStore.Data
{
    public static class ProductLoader
    {
        private static SharpStoreContext context;

        public static string GetProduct(string searhByName, string styleName)
        {
            context = Data.Context;
            StringBuilder sb = new StringBuilder();
            var navbarLines = StyleChenger.InsertStyle("../../content/products-navbar.html", $"../../content/css/{styleName}.css");

            sb.AppendLine(navbarLines);
            sb.AppendLine("<div class=\"row well products-info\">");

            var knives = context.Knives.Where(k => k.Name.Contains(searhByName));
            if (knives.Count() == 0)
            {
                sb.AppendLine("<h2 class=\"text-center\">There are no knifes.</h2>");
            }
            else
            {
                foreach (var knife in knives)
                {
                    CreateProductView(sb, knife);
                }
            }


            sb.AppendLine("</div>");
            var footer = File.ReadLines("../../content/products-footer.html");
            foreach (var footerLine in footer)
            {
                sb.AppendLine(footerLine);
            }

            return sb.ToString();
        }

        private static void CreateProductView(StringBuilder sb, Knife knife)
        {
            sb.AppendLine("<div class=\"col-lg-3 col-md-3 col-sm-6 col-xs-12 \" >");
            sb.AppendLine($"<img src=\"{knife.ImageURL}\"  alt=\"knife-img\" class=\"img-rounded img-responsive\"/>");
            sb.AppendLine($"<h3>{knife.Name}</h3>");
            sb.AppendLine($"<p>{knife.Price}</p>");
            sb.AppendLine("<input type=\"submit\" value=\"Buy Now\" name=\"buyKnife\" class=\"btn btn-primary\">\r\n</div>");
        }
    }
}
