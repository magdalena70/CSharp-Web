using PizzaMore.App.Utillities;
using SimpleMVC.Interfaces;

namespace PizzaMore.App.Views.Home
{
    public class IndexDE : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/home-de.html");
            return htmlContent;
        }
    }
}
