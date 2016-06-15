namespace Participation_ASP.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Skill(int id, string description)
        {
            Id = id;
            Description = description;
        }

        //Temporary Skill
        public Skill(string description)
        {
            Description = description;
        }
    }
}