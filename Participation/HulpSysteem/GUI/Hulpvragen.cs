using Participation.HulpSysteem.Logic;
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
        HPSLogic hpsLogic;
        //TODO HPS.1 Impliment below
        //Patient patient = currentUser;
        public RequestForm()
        {
            InitializeComponent();
            for (int i = 0; i <= 5; i++)
            {
                urgencyLbx.Items.Add(i);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            var perks = new List<string>();
            foreach (var perk in perksClb.CheckedItems)
            {
                perks.Add(perk.ToString());
            }
            if (titleTbx.Text == "")
                MessageBox.Show("Vul de titel in");
            else if (descriptionTbx.Text == "")
                MessageBox.Show("Vul de beschrijving in");
            else if (locationTbx.Text == "")
                MessageBox.Show("Vul uw woonplaats in");
            else if (dateDtp.Value == DateTime.Today || dateDtp.Value < DateTime.Today || dateDtp.Value == null)
                MessageBox.Show("Vul een geldige datum in");
            else
            {
                var request = new Request(titleTbx.Text, descriptionTbx.Text, perks, locationTbx.Text, dateDtp.Value, (int)urgencyLbx.SelectedItem);
                MessageBox.Show("Test: \n" + request.ToString());
            }


            //TODO HPS.1 including below
            //hpsLogic.AddRequest(patient, request);
        }
    }
}
