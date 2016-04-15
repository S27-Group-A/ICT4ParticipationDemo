using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation
{
    public class LISLogic
    {
        #region Databaseless testing
        private List<Patient> _patients = new List<Patient>();
        private List<Volunteer> _volunteers = new List<Volunteer>();
        #endregion

        public bool AddUser(IUser user)
        {
            //TODO Add database context to add user to database

            #region Databaseless testing

            if (GetUsers().Exists(element => element != user))
            {
                try
                {
                    if (user.GetType() == typeof(Patient))
                    {
                        _patients.Add(user as Patient);
                    }
                    else if (user.GetType() == typeof (Volunteer))
                    {
                        _volunteers.Add(user as Volunteer);
                    }
                    return true;
                }
                catch
                {
                    throw new Exception("Failed to add: " + user.Name);
                }

            }
            MessageBox.Show("Failed to add user: User: " + user.Name + " already exists");
            return false;


            #endregion
        }

        public IUser GetUser(string email)
        {
            #region Databaseless testing

            foreach (var user in GetUsers())
            {
                if (user.Email == email)
                    return user;
            }
            return null;

            #endregion
        }
 
        private List<IUser> GetUsers()
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
    }
}
