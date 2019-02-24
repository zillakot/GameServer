using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GameServer
{
    public class ServerHandleData
    {
        public delegate void Packet(int connectionID, byte[] data);
        public static Dictionary<int, Packet> packets = new Dictionary<int, Packet>();
        public static void InitializePackets()
        {

        }
        public static void HandleData(int connectionID, byte[] data)
        {
            byte[] buffer = (byte[])data.Clone();
            int pLength = 0;

            
        }
    }
}