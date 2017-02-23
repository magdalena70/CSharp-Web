using SimpleHttpServer;
using SimpleMVC.App.MVC;

namespace SimpleMVC.App
{
    class AppStart
    {
        static void Main()
        {
            //NotesAppContext context = new NotesAppContext();
            //context.Database.Initialize(true);

            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}
