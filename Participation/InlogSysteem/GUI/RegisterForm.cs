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
using Phidgets;
using Phidgets.Events;
using S21M_RailB;

namespace Participation.InlogSysteem.GUI
{
    public partial class RegisterForm : Form
    {
        private static readonly string _succesfullRegisterationMsg = "Uw account is geregistreerd u kunt nu inloggen";

        private static readonly string _contactAdministratorMsg =
            "Er is iets misgegaan neem contact op met de administrator";

        private LISLogic _lisLogic = new LISLogic();

        private List<string> _perks = new List<string>();

        private RFIDManager rfidManager;

        public RegisterForm()
        {
            InitializeComponent();
            ControlBox = false;
            rfidManager = new RFIDManager();

            tbxProfilePictureUrl.Enabled = false;
            tbxVOGUrl.Enabled = false;
            if (!rbtNeedHelp.Checked && !rbtCanHelp.Checked)
            {
                pnlInformation.Hide();
            }
        }


        private void needHelpRbt_CheckedChanged(object sender, EventArgs e)
        {
            pnlInformation.Show();
            if (rbtNeedHelp.Checked)
                HideVogAndPerks();
            else if (rbtCanHelp.Checked)
                ShowVogAndPerks();
        }

        private void canHelpRbt_CheckedChanged(object sender, EventArgs e)
        {
            pnlInformation.Show();
            if (rbtNeedHelp.Checked)
                HideVogAndPerks();
            else if (rbtCanHelp.Checked)
                ShowVogAndPerks();
        }

        private void ShowVogAndPerks()
        {
            gbxPerks.Show();
            gbxVOG.Show();
        }

        private void HideVogAndPerks()
        {
            gbxPerks.Hide();
            gbxVOG.Hide();
        }

        private bool CheckFields()
        {

            if (tbxPassword.Text != tbxRepeatPassword.Text)
                MessageBox.Show("Het herhaalde wachtwoord komt niet overheen met het originele wachtwoord");
            if (!string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPassword.Text)
                && !string.IsNullOrEmpty(tbxRepeatPassword.Text) && !string.IsNullOrEmpty(tbxLocation.Text)
                && tbxPassword.Text == tbxRepeatPassword.Text && !string.IsNullOrEmpty(tbxName.Text))
            {
                if ((rbtCanHelp.Checked && !string.IsNullOrEmpty(tbxVOGUrl.Text)) || rbtNeedHelp.Checked)
                    return true;
                return false;
            }
            return false;
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                if (rbtNeedHelp.Checked)
                {
                    if (rbtMale.Checked)
                    {
                        var newPatient = new Patient(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Male,
                            tbxPassword.Text);
                        if (_lisLogic.AddUser(newPatient))
                        {
                            MessageBox.Show(_succesfullRegisterationMsg);
                        }
                        else MessageBox.Show(_contactAdministratorMsg);
                    }
                    if (rbtFemale.Checked)
                    {
                        var newPatient =
                            new Patient(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Female,
                            tbxPassword.Text);
                        if (_lisLogic.AddUser(newPatient))
                            MessageBox.Show(_succesfullRegisterationMsg);
                        else MessageBox.Show(_contactAdministratorMsg);
                    }
                }
                if (rbtCanHelp.Checked)
                {
                    if (rbtMale.Checked)
                    {
                        var newVolunteer = new Volunteer(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Male,
                            tbxPassword.Text, tbxVOGUrl.Text);
                        if (_lisLogic.AddUser(newVolunteer))
                        {
                            //Add Perks
                            var perks = lblPerks.Text.Split('+').ToList();
                            if (perks.Count > 0)
                            {

                                if (perks.Count > 0)
                                {
                                    foreach (var perk in perks)
                                    {
                                        if(perk != "")
                                            _lisLogic.AddPerk(newVolunteer, perk);
                                    }
                                }
                            }


                            MessageBox.Show(_succesfullRegisterationMsg);
                        }
                        else MessageBox.Show(_contactAdministratorMsg);
                    }
                    if (rbtFemale.Checked)
                    {
                        var newVolunteer = new Volunteer(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Female,
                            tbxPassword.Text, tbxVOGUrl.Text);
                        if (_lisLogic.AddUser(newVolunteer))
                        {

                            //Add perk
                            var perks = lblPerks.Text.Split('+').ToList();
                            if (perks.Count > 0)
                            {

                                if (perks.Count > 0)
                                {
                                    foreach (var perk in perks)
                                    {

                                        _lisLogic.AddPerk(newVolunteer, perk);
                                    }
                                }
                            }

                            MessageBox.Show(_succesfullRegisterationMsg);
                        }
                        else MessageBox.Show(_contactAdministratorMsg);
                    }
                }
                //TODO Add files (VOG and Profilepicture) to server
            }
            else
            {
                MessageBox.Show("U heeft niet alle gegevens goed toegevoegd.", "Foutmelding", MessageBoxButtons.OK);
            }
        }

        private void browseProfilePictureBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg; *.png; *.bmp ";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    tbxProfilePictureUrl.Text = ofd.FileName;
                    pbProfilePic.Image = Image.FromFile(sourceFile);
                }

            }
        }

        private void browseVogUrlBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg; *.png; *.bmp; *.pdf; *.docx ";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string sourceFile = ofd.FileName;
                    tbxVOGUrl.Text = ofd.FileName;
                }

            }
        }

        private void addPerkTbx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPerk.Text))
            {
                _perks.Add(tbxPerk.Text);
                lblPerks.Text += "+" + tbxPerk.Text;
                tbxPerk.Clear();
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            FormProvider.StartMenu.Show();
            FormProvider.RegisterForm.Hide();
        }

        private void RegisterForm_Closed(object sender, EventArgs e)
        {
            FormProvider.StartMenu.Show();
        }

        private void femaleRbt_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
