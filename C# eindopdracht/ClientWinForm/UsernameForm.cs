﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientWinForm
{
    public partial class UsernameForm : Form
    {
        private string username;
        public UsernameForm()
        {
            InitializeComponent();
        }
        public string getUsername()
        {
            username = usernameInput.Text;
            return username;
        }

    }
}
