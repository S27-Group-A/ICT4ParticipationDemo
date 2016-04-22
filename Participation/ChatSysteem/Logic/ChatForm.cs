using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Participation.ChatSysteem.ChatService;
using Participation.SharedModels;

namespace Participation.ChatSysteem
{
    public partial class ChatForm : Form
    {
        ReceiveClient RecieveClient;
        string myName;
        public ChatForm(ReceiveClient recieveClient, string target)

        {
            InitializeComponent();
            this.FormClosing+=new FormClosingEventHandler(frmClient_FormClosing);
            this.txtSend.KeyPress += new KeyPressEventHandler(txtSend_KeyPress);
            this.RecieveClient = recieveClient;
            this.tbxName.Text = target;
            
        }

        public ChatForm(ReceiveClient recieveClient, string sender, string message)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(frmClient_FormClosing);
            this.txtSend.KeyPress += new KeyPressEventHandler(txtSend_KeyPress);
            this.RecieveClient = recieveClient;
            if (message.Length > 0)
                tbxMessage.Text += Environment.NewLine + sender + ">" + message;
            this.tbxName.Text = sender;

        }

        void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            int keyValue = (int)e.KeyChar;

            if (keyValue == 13)
            {
                SendMessage();
                txtSend.Clear();
            }
        }

        private void frmClient_FormClosing(object sender, EventArgs e)
        {
            RecieveClient.Stop(FormProvider.LoggedInUser);
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            tbxMessage.Enabled = false;
            txtSend.Enabled = false;
            btnSend.Enabled = false;
        }

        void rc_ReceiveMsg(string sender, string msg)
        {
            if (msg.Length > 0)
                tbxMessage.Text +=Environment.NewLine + sender +">"+ msg;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (tbxName.Text != string.Empty)
            {
                tbxMessage.Text += Environment.NewLine + FormProvider.LoggedInUser.Name + ">" + txtSend.Text;
                RecieveClient.SendMessage(txtSend.Text, myName, tbxName.Text);
                txtSend.Clear();
            }
        }
    }
   
}
