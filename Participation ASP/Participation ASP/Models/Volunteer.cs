﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Volunteer : Account
    {
        public DateTime BirthDate { get; set; }
        public string Photo { get; set; }
        public string Vog { get; set; }
        public bool VogConfirmation { get; set; }

        public Volunteer(int accountId, string username, string password, string email, string name, string phone,
            DateTime dateCancellation, string address, string location, bool hasCar, bool hasDriversLicense, string rfid,
            bool banned, DateTime unban, bool enabled, DateTime birthDate, string photo, string vog, bool vogConfirmation)
            : base(
                accountId, username, password, email, name, phone, dateCancellation, address, location, hasCar,
                hasDriversLicense, rfid, banned, unban, enabled)
        {
            this.BirthDate = birthDate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
        }
    }
}