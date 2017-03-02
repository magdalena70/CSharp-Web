using PizzaMore.App.Utillities;
using PizzaMore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace PizzaMore.App.Views.Menu
{
    public class Details : IRenderable<PizzaDetailsViewModel>
    {
        public PizzaDetailsViewModel Model { get; set; }

        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/details.html");
            return string.Format(htmlContent, Model.ToString());
        }
    }
}
