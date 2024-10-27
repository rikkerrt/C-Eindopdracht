using System.Runtime.CompilerServices;
using System.Threading;

namespace ClientWinForm {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
            
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox = new System.Windows.Forms.TextBox();
            this.activeConnections = new System.Windows.Forms.ListBox();
            this.messageBox = new System.Windows.Forms.ListBox();
            this.sendButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientBindingSource
            // 
            this.clientBindingSource.CurrentChanged += new System.EventHandler(this.clientBindingSource_CurrentChanged);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(226, 426);
            this.textBox.Margin = new System.Windows.Forms.Padding(2);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(323, 20);
            this.textBox.TabIndex = 1;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // activeConnections
            // 
            this.activeConnections.Items.AddRange(new object[] {
            "Active connections in this session:"});
            this.activeConnections.Location = new System.Drawing.Point(11, 0);
            this.activeConnections.Name = "activeConnections";
            this.activeConnections.Size = new System.Drawing.Size(210, 446);
            this.activeConnections.TabIndex = 0;
            // 
            // messageBox
            // 
            this.messageBox.FormattingEnabled = true;
            this.messageBox.Location = new System.Drawing.Point(226, 0);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(427, 420);
            this.messageBox.TabIndex = 2;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(562, 426);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(91, 23);
            this.sendButton.TabIndex = 3;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButtonClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 452);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.activeConnections);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Chat client";
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void addToMessageBox(string message) {

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.ListBox activeConnections;
        private System.Windows.Forms.ListBox chatWindow;
        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.ListBox messageBox;
        private System.Windows.Forms.Button sendButton;
    }
}

