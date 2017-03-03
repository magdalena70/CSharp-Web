using SimpleHttpServer;
using SimpleMVC;

namespace Shouter.App
{
    public class AppStart
    {
        static void Main(string[] args)
        {
            Data.Data.Context.Database.Initialize(true);

            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "Shouter.App");
        }
    }
}
