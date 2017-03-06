using System.IO;
using SoftUniStore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;
using System.Text;
using SimpleMVC.Interfaces;
using SoftUniStore.App.Models;
using System;
using System.Collections.Generic;

namespace SoftUniStore.App.Views.Admin
{
    public class Games : IRenderable<ICollection<AdminGamesViewModel>>
    {
        public ICollection<AdminGamesViewModel> Model { get; set; }

        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavLogged = File.ReadAllText("../../Content/nav-logged.html");
            string htmlContent = File.ReadAllText("../../Content/admin-games.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            StringBuilder bd = new StringBuilder();
            foreach (var game in Model)
            {
                bd.AppendLine(game.ToString());

            }

            htmlContent = htmlContent.Replace("##games##", bd.ToString());
            return htmlHeader + htmlNavLogged + htmlContent + htmlFooter;
        }
    }
}
