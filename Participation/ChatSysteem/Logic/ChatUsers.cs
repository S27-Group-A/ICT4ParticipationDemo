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

namespace Participation.ChatSysteem
{
    public partial class ChatUsers : Form
    {
        ReceiveClient rc = null;
        public ChatUsers()
        {
            InitializeComponent();
        }

        public void Login()
        {
            rc = new ReceiveClient();
            rc.Start(rc, FormProvider.LoggedInUser);

            rc.NewNames += new GotNames(rc_NewNames);
        }

        private void rc_NewNames(object sender, List<string> names)
        {
            lstClients.Items.Clear();
            foreach (string name in names)
            {
                if (name != myName)
                    lstClients.Items.Add(name);
            }
        }

        private void btnStartChat_Click(object sender, EventArgs e)
        {

        }
    }
}
