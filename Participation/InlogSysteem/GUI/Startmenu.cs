using System;
using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;
using SharedModels.Debug;

namespace Participation
{
    public partial class Startmenu : Form
    {
        private readonly LISLogic _lisLogic = new LISLogic();


        public Startmenu()
        {
            InitializeComponent();
            Hide();
        }
        /// <summary>
        /// Logs-in on click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startMenuLogInBtn_Click(object sender, EventArgs e)
        {
            if (CheckFields())
            {
                IUser user;
                try
                {
                    user = _lisLogic.GetUser(emailTbx.Text);

                    if (user.Password == passwordTbx.Text)
                        LogIn(user);
                    else
                    {
                        MessageBox.Show("Het ingevulde wachtwoord was onjuist, probeer het nogmaals");
                        ClearFields();
                    }
                }
                catch (Exception exception)
                {
                    Logger.Write(exception.Message);
                    MessageBox.Show("Het ingevulde e-mail adres is niet gevonden of bestaat niet, neem contact op met de administrator en/of controleer uw gegevens");
                    ClearFields();
                    MessageBox.Show("Vul uw gegevens opnieuw in");
                }
            }
            else
            {
                ClearFields();
                MessageBox.Show("Vul uw e-mail adres en wachtwoord in");
            }
        }

        /// <summary>
        /// Register on click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startMenuRegisterBtn_Click(object sender, EventArgs e)
        {
            FormProvider.RegisterForm.Show();
            FormProvider.StartMenu.Hide();
        }

        /// <summary>
        /// Checks fields
        /// </summary>
        /// <returns></returns>
        private bool CheckFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(passwordTbx.Text))
                return true;
            return false;
        }

        /// <summary>
        /// Clears fields
        /// </summary>
        private void ClearFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(passwordTbx.Text))
            {
                emailTbx.Clear();
                passwordTbx.Clear();
            }
        }

        /// <summary>
        /// Logs in the user
        /// </summary>
        /// <param name="user"></param>
        private void LogIn(IUser user)
        {
            if (user.Birthday != DateTime.MinValue || !string.IsNullOrEmpty(user.Location) ||
                !string.IsNullOrEmpty(user.Name))
            {
                if (typeof(Volunteer) == user.GetType())
                {
                    var admin = user as Volunteer;
                    //MessageBox.Show(admin.isAdmin.ToString());
                    if (admin.isAdmin)
                    {
                        FormProvider.LoggedInUser = admin;
                        FormProvider.AdminSystemForm.Show();
                        FormProvider.StartMenu.Hide();
                    }
                    else if (!admin.isAdmin)
                    {
                        FormProvider.LoggedInUser = user;
                        FormProvider.ProfileForm.Show();
                        FormProvider.StartMenu.Hide();
                    }
                }
                if (typeof(Patient) == user.GetType())
                {
                    FormProvider.LoggedInUser = user;
                    FormProvider.ProfileForm.Show();
                    FormProvider.StartMenu.Hide();
                }
            }
        }
    }
}