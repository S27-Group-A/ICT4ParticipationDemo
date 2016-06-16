// <copyright file="IAccount.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface of the account, used to store volunteers and patient.
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// Gets or sets the account id.
        /// </summary>
        int AccountId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        string Username { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Gets or sets the phone.
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Gets or sets the date of cancellation
        /// </summary>
        DateTime DateCancellation { get; set; }

        /// <summary>
        /// Gets or sets the adress.
        /// </summary>
        string Adress { get; set; }

        /// <summary>
        /// Gets or sets the location
        /// </summary>
        string Location { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account has a car.
        /// </summary>
        bool HasCar { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account has a license.
        /// </summary>
        bool HasDriversLicense { get; set; }

        /// <summary>
        /// Gets or sets the RFID.
        /// </summary>
        string Rfid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the account is an admin.
        /// </summary>
        bool IsAdmin { get; set; }

        IAccount LoginAccount(IAccount account);
    }
}
