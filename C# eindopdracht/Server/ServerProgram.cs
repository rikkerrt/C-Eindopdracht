using System.Data;
using System.IO.Enumeration;
using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server {
    public class Server {
        public static List<Connection> connections = new List<Connection>();
        private static Log log = new Log();

        public static void Main(string[] args) {
            IPAddress localhost = IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(localhost, 1212);
          

            listener.Start();

            while (true) {
                Console.WriteLine("Waiting for Connection");
 //               Console.WriteLine(connections.Count);

                TcpClient client = listener.AcceptTcpClient();

                Thread thread = new Thread(ClientHandler);
                thread.Start(client);

                Thread logThread = new Thread(logWaiter);
                logThread.Start();
            }
        }

        private static void logWaiter() {
            while (true) {
                string consoleCommand = Console.ReadLine();

                if (consoleCommand.Equals("log")) {
                    log.ReadLog();
                }
            }
        }

        static void ClientHandler(object obj) {
            TcpClient client = obj as TcpClient;

            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);
            string username = "";

            while (username.Equals("")) {
                username = stream.ReadLine();
            }
            connections.Add(new Connection(client, username));

            var streamWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

            ServerNotification(username, "connected");
            log.writeConnect(username);
            //WriteTextMessageToAll("Server: Client with username: " + username + " has connected.");

            bool done = false;
            while (!done) {
                //string received = client.ReadTextMessage(client);
                //Console.WriteLine(received);

                //done = received.Equals("Disconnect");
            }
            client.Close();
            Console.WriteLine("Connection lost");
        }

        public static void WriteTextMessageToAll(string text) {
            log.writeMessage(text);

            foreach (Connection conn in connections) {
                conn.WriteMessage(text);
            }
        }

        public static void ServerNotification(string notification, string status) {
            foreach (Connection conn in connections) {
                conn.WriteMessage("Server|| User with name: " + notification + " has " + status);
            }
        }

        public class Connection {
            public string username { get; set; }
            private TcpClient client { get; set; }
            public Connection(TcpClient client, string username) {
                this.client = client;
                this.username = username;

                Thread thread = new Thread(ReadTextMessage);
                thread.Start(client);
            }

            public async void ReadTextMessage(object obj) {
                TcpClient client = obj as TcpClient;
                while (true) {
                    try
                    {
                        var stream = new StreamReader(client.GetStream(), Encoding.UTF8);
                        string recieved = await stream.ReadLineAsync();
                        if (recieved.Equals("Disconnect"))
                        {
                            log.writeDisconnect(username);
                            connections.Remove(this);
                            client.GetStream().Close();
                            client.Close();
                            break;
                        }

                        Console.WriteLine(recieved);
                        WriteTextMessageToAll(recieved);
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }
            }

            public void WriteMessage(string message) {
                var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);
         
                {
                    stream.WriteLine(message);
                    stream.Flush();
                }                 
            }
           
        }

        public class Log {
            private readonly string fileName = "C:\\Temp\\serverLog.txt";
            private string message { get; set; }
            private StreamWriter writer;

           public Log () {
                if (!File.Exists(fileName)) {
                    using StreamWriter writer = new StreamWriter(fileName,true);
                }
            }

            public string ReadLog() {
                
                StreamReader reader = new StreamReader(fileName, Encoding.ASCII);
                string readerRead = reader.ReadToEnd();
                Console.WriteLine(readerRead);
                reader.Close();
                return readerRead;
            }

            public string  ReadLastLine()
            {
                StreamReader reader = new StreamReader(fileName, Encoding.ASCII);
                string readerRead = File.ReadAllLines(fileName).Last();
                reader.Close();
                return readerRead;
            }

            public void writeConnect(string data) {
                writer = new StreamWriter(fileName, true);
                writer.WriteLine(DateTime.Now + "| User connected to server: " + data);
                writer.Flush();
                writer.Close();
            }

            public void writeDisconnect(string data) {
                writer = new StreamWriter(fileName, true);
                writer.WriteLine(DateTime.Now + "| User disconnected from server: " + data);
                writer.Flush();
                writer.Close();
            }

            public void writeMessage(string data) {
                writer = new StreamWriter(fileName, true);
                writer.Write("\n"+ DateTime.Now + "| User send message: " + data);
                writer.Flush();
                writer.Close();
            }

            
        }
    }
}

