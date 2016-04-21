﻿using System;
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
       
        public ChatForm(ReceiveClient recieveClient)
        {
            InitializeComponent();
            this.FormClosing+=new FormClosingEventHandler(frmClient_FormClosing);
            this.txtSend.KeyPress += new KeyPressEventHandler(txtSend_KeyPress);
            this.RecieveClient = recieveClient;
            
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
            txtMsgs.Enabled = false;
            txtSend.Enabled = false;
            btnSend.Enabled = false;
        }

        void rc_ReceiveMsg(string sender, string msg)
        {
            if (msg.Length > 0)
                txtMsgs.Text +=Environment.NewLine + sender +">"+ msg;
        }

        void rc_NewNames(object sender, List<string> names)
        {
            lstClients.Items.Clear();
            foreach (string name in names)
            {
                if (name!=myName)
                    lstClients.Items.Add(name);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            if (lstClients.Items.Count != 0)
            {
                txtMsgs.Text += Environment.NewLine + myName + ">" + txtSend.Text;
                if (lstClients.SelectedItems.Count == 0)
                    RecieveClient.SendMessage(txtSend.Text, myName, lstClients.Items[0].ToString());
                else
                    if (!string.IsNullOrEmpty(lstClients.SelectedItem.ToString()))
                        RecieveClient.SendMessage(txtSend.Text, myName, lstClients.SelectedItem.ToString());

                txtSend.Clear();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0)
            {
                txtMsgs.Enabled = true;
                txtSend.Enabled = true;
                btnSend.Enabled = true;

                myName = txtUserName.Text.Trim();

                RecieveClient = new ReceiveClient();
                RecieveClient.Start(RecieveClient, FormProvider.LoggedInUser);

                RecieveClient.NewNames += new GotNames(rc_NewNames);
                RecieveClient.ReceiveMsg += new ReceivedMessage(rc_ReceiveMsg);
            }
            else
            {
                txtMsgs.Enabled = false;
                txtSend.Enabled = false;
                btnSend.Enabled = false;
            }
        }

    }
   
}