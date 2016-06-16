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

        public string Adress { get; set; }

        public string Location { get; set; }

        public bool HasCar { get; set; }

        public bool HasDriversLicense { get; set; }

        public string Rfid { get; set; }

        public bool Banned { get; set; }

        public DateTime Unban { get; set; }

        public bool Enabled { get; set; }

        public bool IsAdmin { get; set; }

        public Account()
        {
        }

        public Account(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool banned, DateTime unban, bool enabled, bool isAdmin)
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
            this.Banned = banned;
            this.Unban = unban;
            this.Enabled = enabled;
        }


        public IAccount LoginAccount(IAccount loginAccount)
        {
            return DatabaseManager.GetAccount(loginAccount.Email, loginAccount.Password);
        }
    }
}