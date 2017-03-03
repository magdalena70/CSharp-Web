using SimpleMVC.Interfaces;
using System.IO;

namespace Shouter.App.Views.Users
{
    public class Login : IRenderable
    {
        public string Render()
        {
            string html = File.ReadAllText("../../Content/login.html");
            return html;
        }
    }
}
