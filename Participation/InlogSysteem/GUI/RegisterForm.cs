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

namespace Participation.InlogSysteem.GUI
{
    public partial class RegisterForm : Form
    {
        private LISLogic _lisLogic = new LISLogic(); 

        private List<string> _perks = new List<string>(); 

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
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(passwordTbx.Text)
                && !string.IsNullOrEmpty(repeatPasswordTbx.Text) && !string.IsNullOrEmpty(locationTbx.Text) 
                && passwordTbx.Text == repeatPasswordTbx.Text && !string.IsNullOrEmpty(nameTbx.Text))
            {
                if ((canHelpRbt.Checked && !string.IsNullOrEmpty(vogUrlTbx.Text)) || needHelpRbt.Checked)
                    return true;
                return false;
            }
            return false;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                if (needHelpRbt.Checked)
                {
                    if (maleRbt.Checked)
                    {
                        if(_lisLogic.AddUser(new Patient(nameTbx.Text, emailTbx.Text, "", birthdateDtp.Value,
                            profilePictureUrlTbx.Text, locationTbx.Text, phonenumberTbx.Text, "m", passwordTbx.Text)))
                            MessageBox.Show("Uw account is geregistreerd u kunt nu inloggen");
                    }
                    if (femaleRbt.Checked)
                    {
                        if(_lisLogic.AddUser(new Patient(nameTbx.Text, emailTbx.Text, "", birthdateDtp.Value,
                            profilePictureUrlTbx.Text, locationTbx.Text, phonenumberTbx.Text, "f", passwordTbx.Text)))
                        MessageBox.Show("Uw account is geregistreerd u kunt nu inloggen");
                    }
                }
                if (canHelpRbt.Checked)
                {
                    if (maleRbt.Checked)
                    {
                        if (_lisLogic.AddUser(new Volunteer(nameTbx.Text, emailTbx.Text, "", birthdateDtp.Value, profilePictureUrlTbx.Text, locationTbx.Text, phonenumberTbx.Text, "m", passwordTbx.Text, new List<Meeting>(), _perks )))
                            MessageBox.Show("Uw account is geregistreerd u kunt nu inloggen");
                    }
                    if (femaleRbt.Checked)
                    {
                        if (_lisLogic.AddUser(new Volunteer(nameTbx.Text, emailTbx.Text, "", birthdateDtp.Value, profilePictureUrlTbx.Text, locationTbx.Text, phonenumberTbx.Text, "f", passwordTbx.Text, new List<Meeting>(), _perks)))
                            MessageBox.Show("Uw account is geregistreerd u kunt nu inloggen");
                    }
                }
                //TODO Add files (VOG and Profilepicture) to server
            }
        }

        private void browseProfilePictureBtn_Click(object sender, EventArgs e)
        {
            //TODO Implement
            throw new NotImplementedException();
        }

        private void browseVogUrlBtn_Click(object sender, EventArgs e)
        {
            //TODO Implement
            throw new NotImplementedException();
        }

        private void addPerkTbx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(perkTbx.Text))
            {
                _perks.Add(perkTbx.Text);
                listPerksLbl.Text += " " + perkTbx.Text;
                perkTbx.Clear();
            }
        }
    }
}
