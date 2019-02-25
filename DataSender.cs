using System;
using System.Net.Sockets;

namespace GameServer
{
    public enum ServerPackets
    {
        SWelcomeMessage = 1,
    }
    public static class DataSender
    {
        public static void SendWelcomeMessage(int connectionID)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteInteger((int)ServerPackets.SWelcomeMessage);
            buffer.WriteString("Welcome to the server!");
            ClientManager.SendDataTo(connectionID,buffer.ToArray());
            buffer.Dispose();
        }
    }
}