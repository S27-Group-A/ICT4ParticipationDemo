// <copyright file="Account.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Parent account object, which stores information from the database.
    /// </summary>
    public class Account : IAccount
    {
        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>

        [Required]
        [Display(Name = "Gebruikersnaam")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "{0} moet ten minste {2} karakters lang zijn.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email-adres")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the date of cancellation.
        /// </summary>
        public DateTime DateCancellation { get; set; }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account has a car.
        /// </summary>
        public bool HasCar { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account has a license.
        /// </summary>
        public bool HasDriversLicense { get; set; }

        /// <summary>
        /// Gets or sets the RFID.
        /// </summary>
        public string Rfid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account has admin status..
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountId">The account id.</param>
        /// <param name="username">The account username.</param>
        /// <param name="password">The account password</param>
        /// <param name="email">The account email</param>
        /// <param name="name">The account name.</param>
        /// <param name="phone">The account phone.</param>
        /// <param name="dateCancellation">The account's date of cancellation.</param>
        /// <param name="adress">the account's address/</param>
        /// <param name="location">the location</param>
        /// <param name="hasCar">If account has a car.</param>
        /// <param name="hasDriversLicense">If account has a license</param>
        /// <param name="rfid">RFID of the account</param>
        /// <param name="isAdmin">If account is an admin.</param>
        /// <param name="enabled">If account is enabled.</param>
        public Account(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled)
        {
            this.AccountId = accountId;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Name = name;
            this.Phone = phone;
            this.DateCancellation = dateCancellation;
            this.Adress = adress;
            this.Location = location;
            this.HasCar = hasCar;
            this.HasDriversLicense = hasDriversLicense;
            this.Rfid = rfid;
            this.IsAdmin = isAdmin;
            this.Enabled = enabled;
        }

        /// <summary>
        /// Method used to login to the database.
        /// </summary>
        /// <param name="loginAccount">Account which is used to login with.</param>
        /// <returns></returns>
        public IAccount LoginAccount(IAccount loginAccount)
        {
            return DatabaseManager.GetAccount(loginAccount.Email, loginAccount.Password);
        }
    }
}