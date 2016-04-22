using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.BeheerSysteem.GUI;
using Participation.InlogSysteem.GUI;
using Participation.InlogSysteem.Interfaces;
using Participation.VrijwilligersSysteem.GUI;
using Participation.ChatSysteem;
using Participation.HulpSysteem.GUI;
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


        public static RequestsViewForm RequestsViewForm
        {
            get
            {
                if (_requestsViewForm == null)
                {
                    _requestsViewForm = new RequestsViewForm();
                }
                return _requestsViewForm;
            }
        }
        private static RequestsViewForm _requestsViewForm;


        public static RequestForm RequestForm
        {
            get
            {
                if (_requestForm == null)
                {
                    _requestForm = new RequestForm();
                }
                return _requestForm;
            }
        }
        private static RequestForm _requestForm;



        public static ChatUsers ChatUsersForm
        {
            get
            {
                if (_chatuserform == null)
                {
                    _chatuserform = new ChatUsers();
                }
                return _chatuserform;
            }
        }

        private static ChatUsers _chatuserform;

        public static ChatForm ChatForm(ReceiveClient recieveClient, string target)
        {
            _chatform = new ChatForm(recieveClient, target);

            return _chatform;
        }

        public static ChatForm ChatForm(ReceiveClient recieveClient, string target, string msg)
        {
            _chatform = new ChatForm(recieveClient, target, msg);

            return _chatform;
        }

        private static ChatForm _chatform;

    }
}



