using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static AdminSystemForm _adminSystemForm;
        private static ChatUsers _chatuserform;
        private static ChatForm _chatform;
        private static MeetingForm _meetingForm;
        private static MeetingVolunteerForm _meetingVolunteerForm;

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
                return _profileForm = new ProfileForm(LoggedInUser);
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

        public static AdminSystemForm AdminSystemForm
        {
            get
            {
                if (_adminSystemForm == null)
                {
                    _adminSystemForm = new AdminSystemForm();
                }
                return _adminSystemForm;
            }
        }

        public static MeetingForm MeetingForm
        {
            get
            {
                    return _meetingForm = new MeetingForm();
            }
        }

        public static ChatUsers ChatUsersForm
        {
            get
            {
                return _chatuserform = new ChatUsers();
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

        public static MeetingVolunteerForm MeetingVolunteerForm
        {
            get
            {
                return _meetingVolunteerForm = new MeetingVolunteerForm();
            }
        }
    }
}