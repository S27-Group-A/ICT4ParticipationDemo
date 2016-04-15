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
        //TODO Suggestions to where this should go in the program architecture im open to
        private IUser _loggedInUser;

        private readonly LISLogic _lisLogic = new LISLogic();


        public Startmenu()
        {
            InitializeComponent();
            this.Hide();
        }

        private void startMenuLogInBtn_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                var user = _lisLogic.GetUser(emailTbx.Text);
                if (user.Password == passwordTbx.Text)
                    LogIn(user);
            }
            else
            {
                ClearFields();
                MessageBox.Show("Uw e-mail adres of wachtwoord was incorrect vul uw gegevens opnieuw in");
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
            
            _loggedInUser = user;
            if (_loggedInUser.Birthday != DateTime.MinValue || !string.IsNullOrEmpty(_loggedInUser.Location) ||
                !string.IsNullOrEmpty(_loggedInUser.Name))
            {
                //TODO Pull out next form
                FormProvider.ProfileForm.Show();
                FormProvider.StartMenu.Hide();
            }
            
        }
    }
}
