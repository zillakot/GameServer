using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace GameServer
{
    public static class ClientManager
    {
        public static Dictionary<int, Client> client = new Dictionary<int, Client>();

        public static void CreateNewConnection(TcpClient tempClient){
            Client newClient = new Client();
            newClient.socket = tempClient;
            newClient.connectionID = ((IPEndPoint)tempClient.Client.RemoteEndPoint).Port;
            newClient.Start();
            client.Add(newClient.connectionID, newClient);
        }
    }
}