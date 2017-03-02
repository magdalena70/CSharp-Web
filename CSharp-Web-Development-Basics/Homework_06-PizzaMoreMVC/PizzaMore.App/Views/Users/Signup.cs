using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;

namespace PizzaMore.App.Views.Users
{
    public class Signup : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/signup.html");
            return htmlContent;
        }
    }
}
