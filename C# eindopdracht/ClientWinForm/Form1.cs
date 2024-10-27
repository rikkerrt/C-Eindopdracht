using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForm {
    public partial class Form1 : Form {

        private string username;
        private TcpClient tcpClient;
        public Form1() {
            InitializeComponent();
        }

        private void sendButtonClick(object sender, EventArgs e)
        {
            string userInput = username + ": " + textBox.Text;
            textBox.Clear();
            WriteMessage(tcpClient, userInput);
        }
        private void textBox_TextChanged(object sender, EventArgs e) 
        {

            base.OnLoad(e);
        }
    
        private void clientBindingSource_CurrentChanged(object sender, EventArgs e) {

        }
        protected override void OnLoad(EventArgs e)
        {
            using (UsernameForm form = new UsernameForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    username = form.getUsername();
                    MessageBox.Show("Username: " + username);
                    activeConnections.Items.Add(username);

                     tcpClient = new TcpClient("localhost", 1212);
                    

                    Thread threat = new Thread(ReadMessage);
                    threat.Start(tcpClient);
                }
                 else
                {
                    Application.Exit();
                }
            }
            base.OnLoad(e);
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

        private void ReadMessage(object obj) {
            TcpClient client = obj as TcpClient;

            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);

            while (true) {
                string message = stream.ReadLine();

                if (message != null) {
                    messageBox.Items.Add(message);
                }

                Thread.Sleep(100);
            }

        }

    }

    
}
