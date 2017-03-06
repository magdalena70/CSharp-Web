using System.IO;
using SoftUniStore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace SoftUniStore.App.Views.Admin
{
    public class Delete : IRenderable<DeleteGameViewModel>
    {
        public DeleteGameViewModel Model { get; set; }

        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavLogged = File.ReadAllText("../../Content/nav-logged.html");
            string htmlContent = File.ReadAllText("../../Content/delete-game.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            htmlContent = htmlContent.Replace("##delete##", Model.ToString());
            return htmlHeader + htmlNavLogged + htmlContent + htmlFooter;
        }
    }
}
