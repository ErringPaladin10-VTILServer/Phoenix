using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Phoenix.Chat.Server
{
    public class Bootstrap
    {
        public static void Main(string[] args)
        {
            Console.Title = "Phoenix Chat Server";
            Console.WriteLine("Starting...");

            Database.LoadDb();

            var WS = new WebSocketServer(13422, false);
            var Store = new X509Store("WebHosting", StoreLocation.LocalMachine);
            Store.Open(OpenFlags.ReadOnly);
            //WS.SslConfiguration.ServerCertificate = Store.Certificates[0];
            WS.Log.Level = LogLevel.Info;
            WS.AddWebSocketService<Chat>("/chat");
            WS.Start();

            Console.WriteLine("Ready!");

            while (true) { Thread.Sleep(int.MaxValue); }
        }
    }
}
