using Microsoft.VisualStudio.TestTools.UnitTesting;
using server;
using System.Collections.Generic;
using System.Net.Sockets;

namespace server.Tests
{
    [TestClass()]
    public class ServerTests
    {

        [TestMethod()]
        public void WriteTextMessageToAll_ShouldSendMessageToAllConnections()
        {
            TcpClient tcpClient = new TcpClient("localhost",1212);

            var Connection = new Server.Connection(tcpClient, "Collin");
            Server.connections.Add(Connection);
            Assert.IsTrue(Server.connections.Contains(Connection),"De connectie is correct toegevoegd aan de server!");
        }         
        
    }
}