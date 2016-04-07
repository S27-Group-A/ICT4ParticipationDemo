using Participation.SharedModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class RequestForm : Form
    {
        public RequestForm()
        {
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var perks = new List<string>();
            foreach (var perk in perksClb.CheckedItems)
            {
                perks.Add(perk.ToString());
            }
            var request = new Request(titleTbx.Text, descriptionTbx.Text, perks, locationTbx.Text, dateDtp.Value, (int)urgencyLbx.SelectedValue);
        }

    }
}
