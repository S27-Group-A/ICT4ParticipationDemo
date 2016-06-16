namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Patient : Account
    {
        /// <summary>
        /// gets or sets the ov
        /// </summary>
        public bool Ov { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Patient()
        {

        }

        /// <summary>
        /// Constructor with all properties for patient
        /// </summary>
        /// <param name="ov"></param>
        public Patient(bool ov)
        {
            Ov = ov;
        }

        /// <summary>
        /// constructor with all properties
        /// </summary>
        /// <param name="accountId"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="dateCancellation"></param>
        /// <param name="adress"></param>
        /// <param name="location"></param>
        /// <param name="hasCar"></param>
        /// <param name="hasDriversLicense"></param>
        /// <param name="rfid"></param>
        /// <param name="isAdmin"></param>
        /// <param name="enabled"></param>
        /// <param name="ov"></param>
        public Patient(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled, bool ov) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, isAdmin, enabled)
        {
            this.Ov = ov;
        }

        public bool AddPatient(Patient patient)
        {
            return DatabaseManager.AddAccount(patient);
        }
    }
}