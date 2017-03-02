using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;

namespace PizzaMore.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/home.html");
            return htmlContent;
        }
    }
}
