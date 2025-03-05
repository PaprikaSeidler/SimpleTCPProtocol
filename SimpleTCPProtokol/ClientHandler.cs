using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTCPProtocol
{
    public class ClientHandler
    {
        public static void HandleClient(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint + " connected");
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            bool IsRunning = true;

            while (IsRunning)
            {
                writer.WriteLine("Choose method ('Random', 'Add' or 'Subtract')");
                writer.Flush();

                string? message = reader.ReadLine();
                if (message == null)
                {
                    Console.WriteLine(client.Client.RemoteEndPoint + " disconnected");
                    break;
                }

                Console.WriteLine(message);
                switch (message)
                {
                    case "Random":
                        writer.WriteLine("Input numbers");
                        writer.Flush();
                        string? input = reader.ReadLine();
                        string[] numbers = input.Split(' ');
                        if (numbers.Length == 2 && int.TryParse(numbers[0], out int min) && int.TryParse(numbers[1], out int max))
                        {
                            Random random = new Random();
                            int randomNumber = random.Next(min, max + 1);
                            writer.WriteLine(randomNumber);
                            writer.Flush();
                        }
                        break;

                    case "Add":
                        writer.WriteLine("Input numbers");
                        writer.Flush();
                        input = reader.ReadLine();
                        string[] addNumbers = input.Split(" ");
                        if (addNumbers.Length == 2 && int.TryParse(addNumbers[0], out int firstNumber) && int.TryParse(addNumbers[1], out int secNumber))
                        {
                            int add = firstNumber + secNumber;
                            writer.WriteLine(add);
                            writer.Flush();
                        }
                        break;

                    case "Subtract":
                        writer.WriteLine("Input numbers");
                        writer.Flush();
                        input = reader.ReadLine();
                        string[] subtractNumbers = input.Split(" ");
                        if (subtractNumbers.Length == 2 && int.TryParse(subtractNumbers[0], out int number1) && int.TryParse(subtractNumbers[1], out int number2))
                        {
                            int subtracted = number1 - number2;
                            writer.WriteLine(subtracted);
                            writer.Flush();
                        }
                        break;
                }
            }        
        }
    }
}
