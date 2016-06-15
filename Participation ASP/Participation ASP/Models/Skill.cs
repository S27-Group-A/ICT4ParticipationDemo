namespace Participation_ASP.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Skill(string description)
        {
            this.Description = description;
        }
    }
}