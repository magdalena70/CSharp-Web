using SimpleHttpServer;
using SimpleMVC;

namespace PizzaMore.App
{
    public class AppStart
    {
        public static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8081, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMore.App");
        }
    }
}
