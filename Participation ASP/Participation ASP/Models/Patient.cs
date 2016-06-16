﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Patient : Account
    {
        public bool Ov { get; set; }
        public List<Request> Requests { get; set; }

        public Patient(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool banned, DateTime unban, bool enabled, bool isAdmin, bool ov) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, banned, unban, enabled, isAdmin)
        {
            Ov = ov;
        }
    }
}