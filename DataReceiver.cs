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
        public static coid HandleHelloServer(int connectionID, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            
        }
    }
}