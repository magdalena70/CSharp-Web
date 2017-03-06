using SimpleMVC.Interfaces;
using System.IO;

namespace SoftUniStore.App.Views.Home
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string htmlHeader = File.ReadAllText("../../Content/header.html");
            string htmlNavNotLogged = File.ReadAllText("../../Content/nav-not-logged.html");
            string htmlContent = File.ReadAllText("../../Content/register.html");
            string htmlFooter = File.ReadAllText("../../Content/footer.html");

            return htmlHeader + htmlNavNotLogged + htmlContent + htmlFooter;
        }
    }
}
