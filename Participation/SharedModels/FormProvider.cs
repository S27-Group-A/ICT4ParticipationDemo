using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.BeheerSysteem.GUI;
using Participation.InlogSysteem.GUI;
using Participation.InlogSysteem.Interfaces;
using Participation.VrijwilligersSysteem.GUI;
using UI;

namespace Participation.SharedModels
{
    class FormProvider
    {
        public static IUser LoggedInUser;

        public static Startmenu StartMenu
        {
            get
            {
                if (_startmenu == null)
                {
                    _startmenu = new Startmenu();
                }
                return _startmenu;
            }
        }
        private static Startmenu _startmenu;

        public static RegisterForm RegisterForm
        {

            get
            {
                if (_registerForm == null)
                {
                    _registerForm = new RegisterForm();
                }
                return _registerForm;
            }
        }
        private static RegisterForm _registerForm;

        public static ProfileForm ProfileForm
        {

            get
            {
                if (_profileForm == null)
                {
                    _profileForm = new ProfileForm(LoggedInUser);
                }
                return _profileForm;
            }
        }
        private static ProfileForm _profileForm;

        public static VolunteerForm VolunteerForm
        {

            get
            {
                if (_volunteer == null)
                {
                    _volunteer = new VolunteerForm();
                }
                return _volunteer;
            }
        }
        private static VolunteerForm _volunteer;

       
    }
}

