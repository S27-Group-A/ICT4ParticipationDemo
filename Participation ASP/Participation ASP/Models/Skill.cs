namespace Participation_ASP.Models
{
    public class Skill
    {
        public string Description { get; set; }

        public Skill(string description)
        {
            this.Description = description;
        }
    }
}