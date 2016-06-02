namespace Participation
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Net.Sockets;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;
    using Participation.InlogSysteem.Interfaces;
    using Participation.SharedModels;

    public class LISLogic
    {
        #region Databaseless testing
        private static List<Patient> _patients = new List<Patient>();
        private static List<Volunteer> _volunteers = new List<Volunteer>();
        #endregion

        /// <summary>
        /// Adds the user to the general system can be volunteer or patient
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(IUser user)
        {
            return DatabaseManager.AddUser(user);
            /*
            #region Databaseless testing

            if (GetUsers().Count > 0)
            {
                foreach (var item in GetUsers())
                {
                    if (item != user && item.Email != user.Email)
                    {
                        if (user.GetType() == typeof(Patient))
                        {
                            _patients.Add(user as Patient);
                            return true;
                        }
                        if (user.GetType() == typeof(Volunteer))
                        {
                            _volunteers.Add(user as Volunteer);
                            return true;
                        }

                    }
                }
            }
            else
            {
                if (user.GetType() == typeof(Patient))
                {
                    _patients.Add(user as Patient);
                    return true;
                }
                if (user.GetType() == typeof(Volunteer))
                {
                    _volunteers.Add(user as Volunteer);
                    return true;
                }
            }
            return false;




            #endregion
            */
        }

        /// <summary>
        /// Gets the user from email
        /// </summary>
        /// <param name="email">can be only one email</param>
        /// <returns>the IUser object</returns>
        public IUser GetUser(string email)
        {
            return DatabaseManager.GetUser(email);
        }

        public IUser GetUserByRfid(string rfid)
        {
            return DatabaseManager.GetUserByRfid(rfid);
        }

        public List<IUser> GetUsers()
        {
            return DatabaseManager.GetUsers();
            }


        public bool AddPerk(Volunteer newVolunteer, string perk)
        {
            return DatabaseManager.AddPerk(DatabaseManager.GetUser(newVolunteer.Email), perk);
            //newVolunteer.AddPerk(perk);
        }
    }
}
