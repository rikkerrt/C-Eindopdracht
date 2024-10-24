
using System.Net.Sockets;
using System;
using System.Text;

namespace Client {
    class ClientProgram {
        static void Main(string[] args) {

            TcpClient client = new TcpClient("localhost", 1212);
            setUsername(client);

            Thread threat = new Thread(ReadMessage);
            threat.Start(client);

            while (true) {

            }
        }

        private static void setUsername(TcpClient client) {
            Console.WriteLine("Type your username");
            string message = Console.ReadLine();

            WriteMessage(client, message);
        }

        private static void WriteMessage(TcpClient client, string message) {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);

            stream.WriteLine(message);
            stream.Flush();
        }

        static void ReadMessage(object obj) {
            TcpClient client = obj as TcpClient;

            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);

            while (true) {
                string line = stream.ReadLine();

                if (line != null) {
                    Console.WriteLine(line);
                }

                Thread.Sleep(100);
            }
            
        }
    }
}