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
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
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
        /// Gets or the address.
        /// </summary>
        public string Adress { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        public bool HasCar { get; set; }

        public bool HasDriversLicense { get; set; }

        public string Rfid { get; set; }

        public bool IsAdmin { get; set; }

        public bool Enabled { get; set; }

        public Account()
        {
        }

        public Account(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled)
        {
            AccountId = accountId;
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Phone = phone;
            DateCancellation = dateCancellation;
            Adress = adress;
            Location = location;
            HasCar = hasCar;
            HasDriversLicense = hasDriversLicense;
            Rfid = rfid;
            IsAdmin = isAdmin;
            Enabled = enabled;
        }


        public IAccount LoginAccount(IAccount loginAccount)
        {
            return DatabaseManager.GetAccount(loginAccount.Email, loginAccount.Password);
        }
    }
}