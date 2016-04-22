using Participation.VrijwilligersSysteem.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.InlogSysteem.GUI;
using Participation.InlogSysteem.Interfaces;
using Participation.VrijwilligersSysteem;
using Participation.SharedModels;
using UI;

namespace Participation
{
    public partial class Startmenu : Form
    {

        private LISLogic _lisLogic = new LISLogic();


        public Startmenu()
        {
            InitializeComponent();
            this.Hide();
            DatabaseManager.GetReviews();
        }

        private void startMenuLogInBtn_Click(object sender, EventArgs e)
        {
            if (checkFields())
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
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    ClearFields();
                }
                

            }
            else
            {
                ClearFields();
                MessageBox.Show("Vul uw gegevens opnieuw in");
            }

        }

        private void startMenuRegisterBtn_Click(object sender, EventArgs e)
        {

            FormProvider.RegisterForm.Show();
            FormProvider.StartMenu.Hide();
        }

        private bool checkFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(emailLbl.Text))
                return true;
            return false;
        }

        private void ClearFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(emailLbl.Text))
            {
                emailTbx.Clear();
                passwordTbx.Clear();
            }
        }

        private void LogIn(IUser user)
        {

            if (user.Birthday != DateTime.MinValue || !string.IsNullOrEmpty(user.Location) ||
                !string.IsNullOrEmpty(user.Name))
            {
                FormProvider.LoggedInUser = user;
                FormProvider.ProfileForm.Show();
                FormProvider.StartMenu.Hide();
            }

        }
    }
}
