using Participation.BeheerSysteem.GUI;
using Participation.ChatSysteem;
using Participation.HulpSysteem.GUI;
using Participation.InlogSysteem.GUI;
using Participation.InlogSysteem.Interfaces;
using Participation.VrijwilligersSysteem.GUI;
using UI;

namespace Participation.SharedModels
{
    /// <summary>
    ///     Provides forms
    /// </summary>
    internal class FormProvider
    {
        private static Startmenu _startmenu;
        private static RegisterForm _registerForm;
        private static ProfileForm _profileForm;
        private static VolunteerForm _volunteer;
        private static RequestsViewForm _requestsViewForm;
        private static RequestForm _requestForm;
        private static ChatUsers _chatuserform;
        private static ChatForm _chatform;

        /// <summary>
        ///     Static logged in user used throughout the forms
        /// </summary>
        public static IUser LoggedInUser { get; set; }

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
    }
}