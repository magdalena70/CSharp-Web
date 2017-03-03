using SimpleMVC.Interfaces;
using System.IO;
using System.Text;

namespace Shouter.App.Views.Users
{
    public class Register : IRenderable
    {
        public string Render()
        {
            string html = File.ReadAllText("../../Content/register.html");
            return html;
        }
    }
}
