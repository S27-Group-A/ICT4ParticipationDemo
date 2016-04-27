// <copyright file="ChatForm.cs" company="S27A">
//      Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace Participation.ChatSysteem
{
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
    public partial class ChatForm : Form
    {
        ReceiveClient RecieveClient;
        private bool NewChat;

        public ChatForm(ReceiveClient recieveClient, string target)

        {
            InitializeComponent();
            this.txtSend.KeyPress += new KeyPressEventHandler(txtSend_KeyPress);
            this.RecieveClient = recieveClient;
            this.RecieveClient.ReceiveMsg += new ReceivedMessage(rc_ReceiveMsg);
            this.tbxName.Text = target;
            this.NewChat = true;
            
        }

        public ChatForm(ReceiveClient recieveClient, string sender, string message)
        {
            InitializeComponent();
            this.txtSend.KeyPress += new KeyPressEventHandler(txtSend_KeyPress);
            this.RecieveClient = recieveClient;
            this.RecieveClient.ReceiveMsg += new ReceivedMessage(rc_ReceiveMsg);
            if (message.Length > 0)
                tbxMessage.Text += Environment.NewLine + sender + ">" + message;
            this.tbxName.Text = sender;
            this.NewChat = false;
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

        private void frmClient_Load(object sender, EventArgs e)
        {
            tbxMessage.Enabled = false;
            txtSend.Enabled = true;
            btnSend.Enabled = true;
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
            if (tbxName.Text != string.Empty && this.NewChat == false)
            {
                tbxMessage.Text += Environment.NewLine + FormProvider.LoggedInUser.Name + ">" + txtSend.Text;
                RecieveClient.SendMessage(txtSend.Text, FormProvider.LoggedInUser.Name, tbxName.Text );
                txtSend.Clear();
            }
            if (tbxName.Text != string.Empty && this.NewChat == true)
            {
                tbxMessage.Text += Environment.NewLine + FormProvider.LoggedInUser.Name + ">" + txtSend.Text;
                RecieveClient.StartChat(txtSend.Text, FormProvider.LoggedInUser.Name, tbxName.Text);
                txtSend.Clear();
            }
        }
    }
   
}
