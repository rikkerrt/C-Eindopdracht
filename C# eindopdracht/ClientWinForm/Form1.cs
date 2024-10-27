using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Form1 : Form
    {

        private string username;
        private TcpClient tcpClient;
        private List<string> users = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void sendButtonClick(object sender, EventArgs e)
        {
            string userInput = username + ": " + textBox.Text;
            textBox.Clear();
            Console.WriteLine("tried to send: " + userInput);
            WriteMessage(tcpClient, userInput);
        }
        private void textBox_TextChanged(object sender, EventArgs e)
        {

            base.OnLoad(e);
        }

        private void clientBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
        protected override void OnLoad(EventArgs e)
        {
            using (UsernameForm form = new UsernameForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    username = form.getUsername();
                    MessageBox.Show("Username: " + username);

                    tcpClient = new TcpClient("localhost", 1212);


                    var streamWriter = new StreamWriter(tcpClient.GetStream(), Encoding.ASCII);
                    streamWriter.WriteLine(username);
                    streamWriter.Flush();

                    ReadMessage(tcpClient);
                }
                else
                {
                    Application.Exit();
                }
            }
            base.OnLoad(e);
        }
        private static void setUsername(TcpClient client)
        {
            Console.WriteLine("Type your username");
            string message = Console.ReadLine();

            WriteMessage(client, message);
        }


        private static void WriteMessage(TcpClient client, string message) {
            var stream = new StreamWriter(client.GetStream(), Encoding.ASCII);

            stream.WriteLine(message);
            stream.Flush();
        }

        private async void ReadMessage(TcpClient client) {
            var stream = new StreamReader(client.GetStream(), Encoding.ASCII);

            while (client.Connected)
            {
                string message = await stream.ReadLineAsync();

                if (message != null)
                {
                    messageBox.Items.Add(message);
                }

            }

        }

    }   
}
