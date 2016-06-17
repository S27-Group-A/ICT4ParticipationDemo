// <copyright file="Availability.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
// <author>Sven Henderickx</author>
namespace Participation_ASP.Models
{
    /// <summary>
    /// Availability of a volunteer.
    /// </summary>
    public class Availability
    {

        /// Gets or sets the day.
        /// </summary>
        public string Day { get; set; }

        /// <summary>
        /// Gets or sets the time of day.
        /// </summary>
        public string TimeOfDay { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Availability"/> class.
        /// </summary>
        /// <param name="day">The day of the week.</param>
        /// <param name="timeOfDay">Time of day, noon, afternoon etc.</param>
        public Availability(string day, string timeOfDay)
        {
            this.Day = day;
            this.TimeOfDay = timeOfDay;
        }
    }
}