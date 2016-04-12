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
using Participation.VrijwilligersSysteem;
using Participation.SharedModels;
using UI;

namespace Participation
{
    public partial class Startmenu : Form
    {
        LISLogic _listLogic = new LISLogic();
        public Startmenu()
        {
            InitializeComponent();



            VolunteerForm test = new VolunteerForm();
            RequestForm reqtest = new RequestForm();
            test.Show();
            reqtest.Show();
            this.Hide();
        }

        private void startMenuLogInBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void startMenuRegisterBtn_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                var user = new User(emailTbx.Text, passwordTbx.Text);
                if (_listLogic.AddUser(user))
                    clearFields();
                else throw new Exception("LISLogic.AddUser() returned false");
            }

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
    }
}
