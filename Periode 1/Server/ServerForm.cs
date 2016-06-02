// <copyright file="ServerForm.cs" company="S27A">
//      Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace Server
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
    public partial class ServerForm : Form
    {
        bool blnStartStop;
        ServiceHost host;
        ChatService cs = new ChatService();
        ServerManager serverManager = new ServerManager();
        

        public ServerForm()
        {
            InitializeComponent();
            blnStartStop = true;
        }

        void cs_ChatListOfVolunteerNames(List<string> names, object sender)
        {
            lbxVolunteer.Items.Clear();
            foreach (string s in names)
            {
                lbxVolunteer.Items.Add(s);
            }
        }

        void cs_ChatListOfElderNames(List<string> names, object sender)
        {
            lbxElder.Items.Clear();
            foreach (string s in names)
            {
                lbxElder.Items.Add(s);
            }
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            
            if (blnStartStop)
            {
                host = new ServiceHost(typeof(Server.ChatService));
                host.Open();
                btnStartStop.Text = "Stop";
                ChatService.ChatListOfElderNames += new ListOfElder(cs_ChatListOfElderNames);
                ChatService.ChatListOfVolunteerNames += new ListOfVolunteer(cs_ChatListOfVolunteerNames);
            }
            else
            {
                cs.Close();
                host.Close();
                btnStartStop.Text = "Start";
            }

            blnStartStop = !blnStartStop;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
