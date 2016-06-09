namespace Participation_ASP.Models
{
    public class Availability
    {
        public string Day { get; set; }
        public string TimeOfDay { get; set; }

        public Availability(string day, string timeOfDay)
        {
            this.Day = day;
            this.TimeOfDay = timeOfDay;
        }
    }
}