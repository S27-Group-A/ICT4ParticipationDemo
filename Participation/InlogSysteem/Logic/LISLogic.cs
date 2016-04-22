﻿using System;
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
        private static List<Patient> _patients = new List<Patient>();
        private static List<Volunteer> _volunteers = new List<Volunteer>();
        #endregion

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

        //TODO Unstaticfy when database connection has been made
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

        internal void AddPerk(Volunteer newVolunteer, string perk)
        {
            newVolunteer.AddPerk(perk);
        }
    }
}
