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
using Participation.BeheerSysteem;
using Participation.Properties;
using Participation.BeheerSysteem.Logic;


namespace Participation.BeheerSysteem.GUI
{
    public partial class AdministratorRights : Form
    {
        public AdministratorRights(User user)
        {
            InitializeComponent();
            
        }

        public void DetectExistingRights()
        {

        }

        private void btnCommitAdminRights_Click(object sender, EventArgs e)
        {

        }
    }
}
