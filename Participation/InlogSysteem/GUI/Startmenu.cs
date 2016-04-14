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
using Participation.VrijwilligersSysteem;
using Participation.SharedModels;
using UI;

namespace Participation
{
    public partial class Startmenu : Form
    {
        //TODO Suggestions to where this should go in the program architecture im open to
        private User _loggedInUser = new User();

        private readonly LISLogic _listLogic = new LISLogic();


        public Startmenu()
        {
            InitializeComponent();


            //VolunteerForm test = new VolunteerForm();
            //RequestForm reqtest = new RequestForm();




            //test.Show();
            //reqtest.Show();
            this.Hide();
        }

        private void startMenuLogInBtn_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                var user = _listLogic.GetUser(emailTbx.Text);
                if (user.Password == passwordTbx.Text)
                    LogIn(user);
            }
            else
            {
                MessageBox.Show("Vul uw e-mail adres en wachtwoord in");
            }

        }

        private void startMenuRegisterBtn_Click(object sender, EventArgs e)
        {
            //_registerForm = new RegisterForm();
            //_registerForm.Show();
            //this.Hide();

            //_registerForm = new RegisterForm();
            FormProvider.RegisterForm.Show();
            FormProvider.StartMenu.Hide();
            /*
            if (checkFields())
            {
                
                var user = new User(emailTbx.Text, passwordTbx.Text);
                if (_listLogic.AddUser(user))
                    clearFields();
                else throw new Exception("LISLogic.AddUser() returned false");
                
            }
            */

        }

        private bool checkFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(emailLbl.Text))
                return true;
            return false;
        }

        private void clearFields()
        {
            if (!string.IsNullOrEmpty(emailTbx.Text) && !string.IsNullOrEmpty(emailLbl.Text))
            {
                emailTbx.Clear();
                passwordTbx.Clear();
            }
        }

        private void LogIn(User user)
        {
            _loggedInUser = user;
            if (_loggedInUser.Birthday != DateTime.MinValue || !string.IsNullOrEmpty(_loggedInUser.Location) ||
                !string.IsNullOrEmpty(_loggedInUser.Name))
            {
                //TODO Pull out next form
                FormProvider.StartMenu.Hide();
            }
            
        }
    }
}
