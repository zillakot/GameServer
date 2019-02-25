using System;

namespace GameServer
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeServer();
            Console.ReadLine();
        }

        private static void InitializeServer()
        {
            ServerTCP.InitializeNetwork();
            Console.WriteLine("Server has been started");
        }
    }
}
