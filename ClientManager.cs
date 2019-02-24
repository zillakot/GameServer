using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GameServer
{
    public static class ClientManager
    {
        public static Dictionary<int, Client> client = new Dictionary<int, Client>();
    }
}