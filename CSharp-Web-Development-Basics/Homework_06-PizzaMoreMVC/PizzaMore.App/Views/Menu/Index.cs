using PizzaMore.App.Utillities;
using PizzaMore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Text;

namespace PizzaMore.App.Views.Menu
{
    public class Index : IRenderable<MenuPizzasViewModel>
    {
        public MenuPizzasViewModel Model { get; set; }


        public string Render()
        {
            StringBuilder bd = new StringBuilder();

            bd.Append(WebUtil.RetrieveFileContent("../../Content/menu-top.html"));
            bd.Append(this.Model.ToString());
            bd.Append(WebUtil.RetrieveFileContent("../../Content/menu-bottom.html"));

            return bd.ToString();
        }
    }
}
