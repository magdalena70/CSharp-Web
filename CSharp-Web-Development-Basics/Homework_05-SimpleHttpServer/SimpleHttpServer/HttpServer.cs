using SimpleHttpServer.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace SimpleHttpServer
{
    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor(routes);
            this.IsActive = true;
        }

        public int Port { get; set; }

        public TcpListener Listener { get; set; }

        public HttpProcessor Processor { get; set; }

        public bool IsActive { get; set; }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();
            while (this.IsActive)
            {
                TcpClient client = this.Listener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    this.Processor.HandleClient(client);
                });

                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}
