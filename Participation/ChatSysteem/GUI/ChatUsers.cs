// <copyright file="ChatUsers.cs" company="S27A">
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
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Participation.SharedModels;
    public partial class ChatUsers : Form
    {
        ReceiveClient rc = null;
        public ChatUsers()
        {
            InitializeComponent();
            btnStartChat.Enabled = false;
            Login();
        }

        public void Login()
        {
            rc = new ReceiveClient();
            rc.Start(rc, FormProvider.LoggedInUser);
            this.FormClosing += new FormClosingEventHandler(ChatUsers_Closing);
            rc.NewNames += new GotNames(rc_NewNames);
            //rc.ReceiveMsg += new ReceivedMessage(rc_ReceiveMessage);
            rc.ChatStart += new NewChat(rc_NewChat);
        }

        private void ChatUsers_Closing(object sender, EventArgs e)
        {
            rc.Stop(FormProvider.LoggedInUser);
        }

        private void rc_NewNames(object sender, List<string> names)
        {
            lbxClients.Items.Clear();
            foreach (string name in names)
            {
                if (name != FormProvider.LoggedInUser.Name)
                    lbxClients.Items.Add(name);
            }
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChatForm CF = FormProvider.ChatForm(this.rc, lbxClients.SelectedItem.ToString());
            CF.ShowDialog();
            this.Show();

        }

        private void rc_NewChat(string msg, string sender, string receiver)
        {
            this.Hide();
            ChatForm CF = FormProvider.ChatForm(this.rc, sender, msg);
            CF.ShowDialog();
            this.Show();
        }

        private void rc_ReceiveMessage(string sender, string msg)
        {
            this.Hide();
            ChatForm CF = FormProvider.ChatForm(this.rc, sender, msg);
            CF.ShowDialog();
            this.Show();
        }

        private void lbxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStartChat.Enabled = true;
        }
    }
}
