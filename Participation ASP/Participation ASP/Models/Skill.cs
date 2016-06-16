namespace Participation_ASP.Models
{
    public class Skill
    {
        /// <summary>
        /// Gets or sets the id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Skill constructor with all properties
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        public Skill(int id, string description)
        {
            Id = id;
            Description = description;
        }

        /// <summary>
        /// constructor with only description
        /// </summary>
        /// <param name="description"></param>
        public Skill(string description)
        {
            Description = description;
        }
    }
}