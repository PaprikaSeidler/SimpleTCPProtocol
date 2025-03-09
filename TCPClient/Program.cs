using System.Net.Sockets;

namespace TCPClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            int port = 7;
            TcpClient client = new TcpClient();
            client.Connect("localhost", port);
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            bool IsRunning = true;
            while (IsRunning)
            {

            }
        }
    }
}
