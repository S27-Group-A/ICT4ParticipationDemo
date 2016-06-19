// <copyright file="Volunteer.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Child of the account class, a volunteer has more rights then a patient.
    /// </summary>
    public class Volunteer : Account
    {
        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the picture reference.
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Gets or sets the vog reference.
        /// </summary>
        public string Vog { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether it is confirmed or not.
        /// </summary>
        public bool VogConfirmation { get; set; }

        /// <summary>
        /// Gets or sets a list of weekly availabilities.
        /// </summary>
        public List<Availability> Availabilities { get; set; }

        /// <summary>
        /// Gets or sets a list of skills.
        /// </summary>
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets a list of reviews.
        /// </summary>
        public List<Review> Reviews { get; set; }

        /// <summary>
        /// Initializes a new default instance of the Volunteer class.
        /// </summary>
        public Volunteer()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Volunteer"/> class.
        /// </summary>
        /// <param name="birthDate">Volunteer birthdate</param>
        /// <param name="photo">Volunteer photo path</param>
        /// <param name="vog">Volunteer good behavior check path.</param>
        /// <param name="vogConfirmation">Volunteer confirmation check.</param>
        /// <param name="availabilities">List of availabilities.</param>
        /// <param name="skills">List of skills</param>
        public Volunteer(DateTime birthDate, string photo, string vog, bool vogConfirmation, List<Availability> availabilities, List<Skill> skills)
        {
            this.BirthDate = birthDate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
            this.Availabilities = availabilities;
            this.Skills = skills;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Volunteer"/> class.
        /// </summary>
        /// <param name="birthDate">Volunteer birthdate</param>
        /// <param name="photo">Volunteer photo path</param>
        /// <param name="vog">Volunteer good behavior check path.</param>
        /// <param name="vogConfirmation">Volunteer confirmation check.</param>
        /// <param name="availabilities">List of availabilities.</param>
        /// <param name="skills">List of skills</param>
        /// <param name="reviews">List of reviews</param>
        public Volunteer(DateTime birthDate, string photo, string vog, bool vogConfirmation, List<Availability> availabilities, List<Skill> skills, List<Review> reviews)
        {
            this.BirthDate = birthDate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
            this.Availabilities = availabilities;
            this.Skills = skills;
            this.Reviews = reviews;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Volunteer"/> class.
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
        /// <param name="birthDate">Volunteer birthdate</param>
        /// <param name="photo">Volunteer photo path</param>
        /// <param name="vog">Volunteer good behavior check path.</param>
        /// <param name="vogConfirmation">Volunteer confirmation check.</param>
        /// <param name="reviews">List of reviews</param>
        public Volunteer(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled, DateTime birthdate, string photo, string vog, bool vogConfirmation, List<Review> reviews) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, isAdmin, enabled)
        {
            this.BirthDate = birthdate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
            this.Reviews = reviews;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Volunteer"/> class.
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
        /// <param name="birthDate">Volunteer birthdate</param>
        /// <param name="photo">Volunteer photo path</param>
        /// <param name="vog">Volunteer good behavior check path.</param>
        /// <param name="vogConfirmation">Volunteer confirmation check.</param>
        public Volunteer(int accountId, string username, string password, string email, string name, string phone, DateTime dateCancellation, string adress, string location, bool hasCar, bool hasDriversLicense, string rfid, bool isAdmin, bool enabled, DateTime birthdate, string photo, string vog, bool vogConfirmation) : base(accountId, username, password, email, name, phone, dateCancellation, adress, location, hasCar, hasDriversLicense, rfid, isAdmin, enabled)
        {
            this.BirthDate = birthdate;
            this.Photo = photo;
            this.Vog = vog;
            this.VogConfirmation = vogConfirmation;
        }


        /// <summary>
        /// Add volunteer, needs to be renamed
        /// </summary>
        /// <param name="volunteer">Creates a new volunteer in the database.</param>
        /// <returns></returns>
        public bool AddPatient(Volunteer volunteer)
        {
            return DatabaseManager.AddAccount(volunteer);
        }

        /// <summary>
        /// Adds a skill to a volunteer
        /// </summary>
        /// <param name="skill">the skill</param>
        public void AddSkill(string skill)
        {
            if (this.Skills == null)
            {
                this.Skills = new List<Skill>();
            }

            DatabaseManager.AddSkill(skill);
            this.Skills.Add(new Skill(skill));
        }

        /// <summary>
        /// Gets the skills of a volunteer
        /// </summary>
        /// <param name="volunteer">The volunteer.</param>
        public void GetSkills(Volunteer volunteer)
        {
            this.Skills = DatabaseManager.GetSkills(volunteer);
        }

        /// <summary>
        /// Gets a list of availabilities of an volunteer.
        /// </summary>
        /// <param name="volunteer">The volunteer.</param>
        public void GetAvailabilities(Volunteer volunteer)
        {
            DatabaseManager.GetAvailabilities(volunteer);
        }

        /// <summary>
        /// Adds a new availability.
        /// </summary>
        /// <param name="day">Which day</param>
        /// <param name="timeOfDay">Which part of the day.</param>
        public void AddAvailabilities(string day, string timeOfDay)
        {
            if (day.Length > 0 && timeOfDay.Length > 0)
            {
                if (this.Availabilities == null)
                {
                    this.Availabilities = new List<Availability>();
                }

                this.Availabilities.Add(new Availability(day, timeOfDay));
            }
        }

        public bool AddVolunteer(Volunteer volunteer)
        {
            return DatabaseManager.AddAccount(volunteer);
        }
    }
}