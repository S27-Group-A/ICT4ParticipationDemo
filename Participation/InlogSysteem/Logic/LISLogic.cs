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
            //TODO Add database context to add user to database

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
        }

        /// <summary>
        /// Gets the user from email
        /// </summary>
        /// <param name="email">can be only one email</param>
        /// <returns>the IUser object</returns>
        public IUser GetUser(string email)
        {
            #region Databaseless testing

            foreach (var user in GetUsers())
            {
                if (user.Email == email)
                    return user;
            }
            throw new Exception("Het e-mail adres: "
                + email + " heeft geen geldig account " +
                "controleer uw inloggegevens");
            #endregion
        }

        // TODO Unstaticfy when database connection has been made
        public static List<IUser> GetUsers()
        {
            #region Databaseless testing

            var getUsers = new List<IUser>();
            foreach (var volunteer in _volunteers)
                getUsers.Add(volunteer);
            foreach (var patient in _patients)
                getUsers.Add(patient);
            return getUsers;

            #endregion
        }

        /// <summary>
        /// Adds the perk to the volunteer
        /// </summary>
        /// <param name="newVolunteer">the volunteer to which the perk is added</param>
        /// <param name="perk">the text of the perk</param>
        internal void AddPerk(Volunteer newVolunteer, string perk)
        {
            newVolunteer.AddPerk(perk);
        }
    }
}
