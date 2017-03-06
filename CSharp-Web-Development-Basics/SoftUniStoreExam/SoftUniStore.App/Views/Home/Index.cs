using System.IO;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.ViewModels;

namespace SoftUniStore.App.Views.Home
{
    public class Index : IRenderable<HomeGamesViewModel>
    {
        public HomeGamesViewModel Model { get; set; }

        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavLogged = File.ReadAllText("../../Content/nav-logged.html");
            string htmlContent = File.ReadAllText("../../Content/home.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            
            htmlContent = htmlContent.Replace("##games##", Model.ToString());
            return htmlHeader + htmlNavLogged + htmlContent + htmlFooter;
        }
    }
}
