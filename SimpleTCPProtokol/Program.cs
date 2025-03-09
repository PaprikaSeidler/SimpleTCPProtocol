﻿using System.Net.Sockets;
using System.Net;


namespace SimpleTCPProtocol
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TCP Server protocol");

            int port = 12000;
            TcpListener listener = new TcpListener(IPAddress.Any, port);
            listener.Start();
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Task.Run(() => ClientHandler.HandleClient(client));
            }
            listener.Stop();
        }
    }
}
