using Microsoft.VisualStudio.TestTools.UnitTesting;
using server;
using System.Collections.Generic;
using System.Net.Sockets;
using static server.Server;

namespace server.Tests
{
    [TestClass()]
    public class ServerTests
    {

        [TestMethod()]
        public void WriteTextMessageToAll_ShouldSendMessageToAllConnections()
        {
            Thread thread = new Thread(startServer);
            thread.Start();

            TcpClient tcpClient = new TcpClient("localhost",1212);

            var Connection = new Connection(tcpClient, "Collin");
            connections.Add(Connection);
            Connection.WriteMessage("This is a test!");

            Log log = new Log();
            Assert.IsTrue(log.ReadLastLine().Contains("User send message: Collin: This is a test!"));
        }         

        public static void startServer()
        {
            Main(new string[0]);
        }
        
    }
}