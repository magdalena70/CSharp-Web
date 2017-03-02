using System;
using SimpleMVC.Interfaces;
using PizzaMore.App.Utillities;

namespace PizzaMore.App.Views.Users
{
    public class Signin : IRenderable
    {
        public string Render()
        {
            string htmlContent = WebUtil.RetrieveFileContent("../../Content/signin.html");
            return htmlContent;
        }
    }
}
