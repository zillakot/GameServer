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

            if(ClientManager.client[connectionID].buffer == null) ClientManager.client[connectionID].buffer = new ByteBuffer();
            ClientManager.client[connectionID].buffer.WriteBytes(buffer);
            
            if(ClientManager.client[connectionID].buffer.Count() == 0)
            {
                ClientManager.client[connectionID].buffer.Clear();
                return;
            }
            if(ClientManager.client[connectionID].buffer.Length() >= 4)
            {
                pLength = ClientManager.client[connectionID].buffer.ReadInteger(false);
                if(pLength <= 0)
                {
                    ClientManager.client[connectionID].buffer.Clear();
                    return;
                }
            }
            while(pLength >= 0 & pLength <= ClientManager.client[connectionID].buffer.Length() - 4)
            {
                if(ClientManager.client[connectionID].buffer.Length >= 4)
                {
                    ClientManager.client[connectionID].buffer.ReadInteger();
                    data = ClientManager.client[connectionID].buffer.ReadBytes(pLength);
                    HandleDataPackets(connectionID, data);
                }

                pLength = 0;
                if(ClientManager.client[connectionID].buffer.Length >= 4)
                {
                    pLength = ClientManager.client[connectionID].buffer.ReadInteger();
                    if(pLength <= 0){
                        ClientManager.client[connectionID].buffer.Clear();
                        return;
                    }
                }
            }
            if(pLength <= 0){
                ClientManager.client[connectionID].buffer.Clear();
            }
        }

        private static void HandleDataPackets(int connectionID, byte[] data)
        {
            ByteBuffer buffer = new ByteBuffer();
            buffer.WriteBytes(data);
            int packetID = buffer.ReadInteger();
            buffer.Dispose();
            if(packets.TryGetValue(packetID, out Packet packet))
            {
                packet.Invoke(connectionID, data);
            }
        }
    }
}