using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace GameServer
{
    public enum ClientPackets
    {
        CHelloServer = 1
    }
    public static class DataReceiver
    {
        public static void HandleHelloServer(int connectionID, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packetID = buffer.ReadInteger();
            string msg = buffer.ReadString();
            buffer.Dispose();
            Console.WriteLine(msg);
        }
    }
}