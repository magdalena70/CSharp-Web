using SimpleHttpServer;
using SimpleMVC.App.Data;
using SimpleMVC.App.MVC;

namespace SimpleMVC.App
{
    class AppStart
    {
        static void Main()
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}
