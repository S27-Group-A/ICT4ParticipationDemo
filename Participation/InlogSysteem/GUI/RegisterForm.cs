using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Participation.SharedModels;
using S21M_RailB;

namespace Participation.InlogSysteem.GUI
{
    public partial class RegisterForm : Form
    {
        private static readonly string _succesfullRegisterationMsg = "Uw account is geregistreerd u kunt nu inloggen";

        private static readonly string _contactAdministratorMsg =
            "Er is iets misgegaan neem contact op met de administrator";

        private readonly LISLogic _lisLogic = new LISLogic();

        private readonly List<string> _perks = new List<string>();

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

        /// <summary>
        ///     Checks all the textboxes if they are empty
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (tbxPassword.Text != tbxRepeatPassword.Text)
                MessageBox.Show("Het herhaalde wachtwoord komt niet overheen met het originele wachtwoord");
            if (IsValidEmail(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPassword.Text)
                && !string.IsNullOrEmpty(tbxRepeatPassword.Text) && !string.IsNullOrEmpty(tbxLocation.Text)
                && tbxPassword.Text == tbxRepeatPassword.Text && !string.IsNullOrEmpty(tbxName.Text)
                && !string.IsNullOrEmpty(tbxProfilePictureUrl.Text))
            {
                if ((rbtCanHelp.Checked && !string.IsNullOrEmpty(tbxVOGUrl.Text)) || rbtNeedHelp.Checked)
                    return true;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     This method checks if the email that's been provided is valid.
        /// </summary>
        /// <param name="email">The email parameter has the email string from the form</param>
        /// <returns>Value indicating whether the email is valid or not.</returns>
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(email,
                @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///     Checks all the input and if it is correct creates an new volunteer or patient
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                            new Patient(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value, tbxProfilePictureUrl.Text,
                                tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Female, tbxPassword.Text);
                        if (_lisLogic.AddUser(newPatient))
                        {
                            MessageBox.Show(_succesfullRegisterationMsg);
                            ClearTextBoxes();
                        }
                        else
                        {
                            MessageBox.Show(_contactAdministratorMsg);
                        }
                    }
                }
                if (rbtCanHelp.Checked)
                {
                    if (rbtMale.Checked)
                    {
                        var newVolunteer = new Volunteer(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Male,
                            tbxPassword.Text, tbxVOGUrl.Text, false);
                        if (_lisLogic.AddUser(newVolunteer))
                        {
                            // Add Perks
                            var perks = lblPerks.Text.Split('+').ToList();
                            if (perks.Count > 0)
                            {
                                if (perks.Count > 0)
                                {
                                    foreach (var perk in perks)
                                    {
                                        if (perk != "")
                                        {
                                            _lisLogic.AddPerk(newVolunteer, perk);
                                        }
                                    }
                                }
                            }


                            MessageBox.Show(_succesfullRegisterationMsg);
                            ClearTextBoxes();
                        }
                        else MessageBox.Show(_contactAdministratorMsg);
                    }
                    if (rbtFemale.Checked)
                    {
                        var newVolunteer = new Volunteer(tbxName.Text, tbxEmail.Text, "", dtpBirthdate.Value,
                            tbxProfilePictureUrl.Text, tbxLocation.Text, tbxPhonenumber.Text, GenderEnum.Female,
                            tbxPassword.Text, tbxVOGUrl.Text, false);
                        if (_lisLogic.AddUser(newVolunteer))
                        {
                            // Add perk
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
                // TODO Add files (VOG and Profilepicture) to server
            }
            else
            {
                MessageBox.Show("U heeft niet alle gegevens goed toegevoegd.", "Foutmelding", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        ///     Clears all the textboxes from their input
        /// </summary>
        private void ClearTextBoxes()
        {
            tbxEmail.Text = "";
            tbxProfilePictureUrl.Text = "";
            tbxVOGUrl.Text = "";
            tbxLocation.Text = "";
            tbxName.Text = "";
            tbxPassword.Text = "";
            tbxRepeatPassword.Text = "";
            tbxPerk.Text = "";
            lblPerks.Text = "";
            tbxPhonenumber.Text = "";
        }


        /// <summary>
        ///     Get an image from your local pc and set it as profilepicture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseProfilePictureBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg; *.png; *.bmp ";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var sourceFile = ofd.FileName;
                    tbxProfilePictureUrl.Text = ofd.FileName;
                    pbProfilePic.Image = Image.FromFile(sourceFile);
                }
            }
        }

        /// <summary>
        ///     get an image from your local pc and set it as vog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseVogUrlBtn_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files | *.jpg; *.png; *.bmp; *.pdf; *.docx ";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var sourceFile = ofd.FileName;
                    tbxVOGUrl.Text = ofd.FileName;
                }
            }
        }

        /// <summary>
        ///     Able to add perks to your perk list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addPerkTbx_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPerk.Text))
            {
                _perks.Add(tbxPerk.Text);
                lblPerks.Text += "+" + tbxPerk.Text;
                tbxPerk.Clear();
            }
        }

        /// <summary>
        ///     sends you back to the loginform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backBtn_Click(object sender, EventArgs e)
        {
            FormProvider.StartMenu.Show();
            FormProvider.RegisterForm.Hide();
        }

        private void RegisterForm_Closed(object sender, EventArgs e)
        {
            FormProvider.StartMenu.Show();
        }

       
    }
}