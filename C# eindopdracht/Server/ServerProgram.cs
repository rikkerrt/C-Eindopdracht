using System.Net;
using System.Net.Sockets;
using System.Text;

class Server {
    static void Main(string[] args) {
        IPAddress localhost = IPAddress.Parse("127.0.0.1");
        TcpListener listener = new TcpListener(localhost, 1212);
        int connetions = 0;

        listener.Start();

        while (true) {
            Console.WriteLine("Waiting for Connection");

            TcpClient client = listener.AcceptTcpClient();

            if (client != null) {
                connetions++;
                Console.WriteLine(connetions);
            }

            Thread thread = new Thread(ClientHandler);
            thread.Start(client);
        }
    }

    static void ClientHandler(object obj) {
        TcpClient client = obj as TcpClient;

        bool done = false;
        while (!done) {
            string received = ReadTextMessage(client);
            Console.WriteLine(received);

            done = received.Equals("Bye");
            if (done) WriteTextMessage(client, "Haudoe");
            else WriteTextMessage(client, "OK");

        }
        client.Close();
        Console.WriteLine("Connection lost");
    }

    public static void WriteTextMessage(TcpClient client, string text) {
        var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);
        {
            stream.WriteLine(text);
            stream.Flush();
        }
    }
    public static string ReadTextMessage(TcpClient client) {
        var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
        {
            return stream.ReadLine();
        }
    }
}