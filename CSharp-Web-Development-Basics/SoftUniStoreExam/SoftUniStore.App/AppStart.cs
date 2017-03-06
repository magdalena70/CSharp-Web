using SimpleHttpServer;
using SimpleMVC;

namespace SoftUniStore.App
{
    class AppStart
    {
        static void Main()
        {
            //Data.Data.Context.Database.Initialize(true);

            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "SoftUniStore.App");

        }
    }
}
