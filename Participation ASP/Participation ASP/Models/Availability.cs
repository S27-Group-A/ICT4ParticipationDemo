namespace Participation_ASP.Models
{
    public class Availability
    {
        /// <summary>
        /// Gets or sets the day
        /// </summary>
        public string Day { get; set; }
        /// <summary>
        /// gets or sets the timeofday
        /// </summary>
        public string TimeOfDay { get; set; }

        /// <summary>
        /// Constructor with all the properties
        /// </summary>
        /// <param name="day"></param>
        /// <param name="timeOfDay"></param>
        public Availability(string day, string timeOfDay)
        {
            this.Day = day;
            this.TimeOfDay = timeOfDay;
        }
    }
}