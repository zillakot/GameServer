using System;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    public static class ServerTCP
    {
        static TcpListener serverSocket = new TcpListener(IPAddress.Any, 5557);
        public static void InitializeNetwork()
        {
            Console.WriteLine("Initializing packets...");
            ServerHandleData.InitializePackets();
            serverSocket.Start();
            serverSocket.BeginAcceptTcpClient(new AsyncCallback(OnClientConnect), null);
        }

        private static void OnClientConnect(IAsyncResult ar)
        {
            TcpClient client = serverSocket.EndAcceptTcpClient(ar);
        }
    }
}