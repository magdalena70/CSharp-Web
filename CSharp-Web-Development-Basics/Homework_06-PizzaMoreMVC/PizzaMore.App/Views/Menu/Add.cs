using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;

namespace PizzaMore.App.Views.Menu
{
    public class Add : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/addpizza.html");
            return htmlContent;
        }
    }
}
