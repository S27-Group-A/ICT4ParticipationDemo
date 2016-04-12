using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Participation.InlogSysteem.GUI
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void needHelpRbt_CheckedChanged(object sender, EventArgs e)
        {
            if(needHelpRbt.Checked)
                HideVogAndPerks();
            else if(canHelpRbt.Checked)
                ShowVogAndPerks();
        }

        private void canHelpRbt_CheckedChanged(object sender, EventArgs e)
        {
            if (needHelpRbt.Checked)
                HideVogAndPerks();
            else if (canHelpRbt.Checked)
                ShowVogAndPerks();
        }

        private void ShowVogAndPerks()
        {
            perksGbx.Show();
            vogGbx.Show();
        }
        private void HideVogAndPerks()
        {
            perksGbx.Hide();
            vogGbx.Hide();
        }

        private bool CheckFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) || !string.IsNullOrEmpty(passwordTbx.Text)
                || !string.IsNullOrEmpty(repeatPasswordTbx.Text) || birthdateDtp.Value != DateTime.Now
                || !string.IsNullOrEmpty(locationTbx.Text))
                return true;
            else
                return false;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                MessageBox.Show("Test");
            }
        }
    }
}
