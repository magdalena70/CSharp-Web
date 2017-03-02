using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;

namespace PizzaMore.App.Views.Home
{
    public class Indexlogged : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/home-logged.html");
            return htmlContent;
        }
    }
}
