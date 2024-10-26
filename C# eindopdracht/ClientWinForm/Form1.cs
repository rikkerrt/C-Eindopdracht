using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForm {
    public partial class Form1 : Form {

        private string username;
        public Form1() {
            InitializeComponent();
        }

        private void sendButtonClick(object sender, EventArgs e)
        {
            string userInput = username + ": " + textBox.Text;
            messageBox.Items.Add(userInput);
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
                }
                 else
                {
                    Application.Exit();
                }
            }
            base.OnLoad(e);
        }

    }

    
}
