using System;
using SimpleMVC.Interfaces;
using System.IO;

namespace SoftUniStore.App.Views.Admin
{
    public class Add : IRenderable
    {
        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavLogged = File.ReadAllText("../../Content/nav-logged.html");
            string htmlContent = File.ReadAllText("../../Content/add-game.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            return htmlHeader + htmlNavLogged + htmlContent + htmlFooter;
        }
    }
}
