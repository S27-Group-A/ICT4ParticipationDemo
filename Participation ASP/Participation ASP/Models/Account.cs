using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Account : IAccount
    {
        public int AccountId { get; set; }

        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public DateTime DateCancellation { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public bool HasCar { get; set; }

        public bool HasDriversLicense { get; set; }

        public string RFID { get; set; }

        public bool Banned { get; set; }

        public DateTime Unban { get; set; }

        public bool Enabled { get; set; }

        public bool IsAdmin { get; set; }


        public Account(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string address, string location, bool hasCar, bool hasDriversLicense, string rfid, bool banned, DateTime unban, bool enabled, bool isAdmin)
        {
            AccountId = accountId;
            Username = username;
            Password = password;
            Email = email;
            Name = name;
            Phone = phone;
            DateCancellation = dateCancellation;
            Address = address;
            Location = location;
            HasCar = hasCar;
            HasDriversLicense = hasDriversLicense;
            RFID = rfid;
            Banned = banned;
            Unban = unban;
            Enabled = enabled;
            IsAdmin = isAdmin;
        }


        public IAccount LoginAccount(IAccount loginAccount)
        {
            return DatabaseManager.Get(loginAccount);
        }
    }
}