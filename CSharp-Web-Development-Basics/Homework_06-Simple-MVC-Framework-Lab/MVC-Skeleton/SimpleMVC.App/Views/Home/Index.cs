using SimpleMVC.App.MVC.Interfaces;

namespace SimpleMVC.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            return "<h3>NotesApp</h3> " +
                "<p><a href=\"/users/register\">Register<a/></p>\r\n" +
                "<p><a href=\"/users/all\">All<a/></p>\r\n" +
                "<p><a href=\"/users/logout\">Logout<a/></p>";
        }
    }
}
