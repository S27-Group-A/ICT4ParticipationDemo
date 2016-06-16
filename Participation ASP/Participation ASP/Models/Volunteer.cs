using System;
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
        public List<Availability> Availabilities { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Review> Reviews { get; set; }

        public Volunteer(DateTime birthDate, string photo, string vog, bool vogConfirmation, List<Availability> availabilities, List<Skill> skills)
        {
            BirthDate = birthDate;
            Photo = photo;
            Vog = vog;
            VogConfirmation = vogConfirmation;
            Availabilities = availabilities;
            Skills = skills;
        }

        public Volunteer(DateTime birthDate, string photo, string vog, bool vogConfirmation, List<Availability> availabilities, List<Skill> skills, List<Review> reviews)
        {
            BirthDate = birthDate;
            Photo = photo;
            Vog = vog;
            VogConfirmation = vogConfirmation;
            Availabilities = availabilities;
            Skills = skills;
            Reviews = reviews;
        }


        public Volunteer(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled, DateTime birthdate, string photo, string vog, bool vogConfirmation, List<Review> reviews) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, isAdmin, enabled)
        {
            this.BirthDate = birthdate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
            this.Reviews = reviews;
        }

        public Volunteer(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled, DateTime birthdate, string photo, string vog, bool vogConfirmation) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, isAdmin, enabled)
        {
            this.BirthDate = birthdate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
        }

        public void AddSkill(string skill)
        {
            if (Skills == null)
            {
                Skills = new List<Skill>();
            }
            DatabaseManager.AddSkill(skill);
            Skills.Add(new Skill(skill));
        }

        public void GetSkills(Volunteer volunteer)
        {
            DatabaseManager.GetSkills(volunteer);
        }

        public void GetAvailabilities(Volunteer volunteer)
        {
            DatabaseManager.GetAvailabilities(volunteer);
        }

        public void AddAvailabilities(string day, string timeOfDay)
        {
            if (day.Length > 0 && timeOfDay.Length > 0)
            {
                if (Availabilities == null)
                {
                    Availabilities = new List<Availability>();
                }
                Availabilities.Add(new Availability(day, timeOfDay));
                //TODO Requires a account id!
                //DatabaseManager.AddAvailability(accountday, timeOfDay);
            }
        }
    }
}