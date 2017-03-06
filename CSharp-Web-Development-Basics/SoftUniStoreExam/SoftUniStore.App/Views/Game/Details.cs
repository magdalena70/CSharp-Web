using System;
using SimpleMVC.Interfaces.Generic;
using SoftUniStore.App.ViewModels;
using System.IO;
using SimpleMVC.Interfaces;

namespace SoftUniStore.App.Views.Game
{
    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }

        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavLogged = File.ReadAllText("../../Content/nav-logged.html");
            string htmlContent = File.ReadAllText("../../Content/game-details.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            htmlContent = htmlContent.Replace("##game##", Model.ToString());
            return htmlHeader + htmlNavLogged + htmlContent + htmlFooter;
        }
    }
}
