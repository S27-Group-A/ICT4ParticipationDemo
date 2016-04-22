using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Participation.SharedModels
{
    public class Volunteer : User
    {
        //properties
        private List<Review> _reviews { get; set; }
        private List<string> _perks { get; set; }
        private string _verklaringPdf { get; set; }
        private static int fileNameCountVerklaring = 0;
        private static int fileNameCountProfilePic = 0;

        //constructors
        public Volunteer(int id, string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password)
            : base(id, name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            _reviews = new List<Review>();
            _perks = new List<string>();
            System.IO.File.Copy(profilePicure, Environment.CurrentDirectory);
        }

        public Volunteer(int id, string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password, string verklaringPdf)
            : base(id, name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            _reviews = new List<Review>();
            _perks = new List<string>();
            System.IO.File.Copy(profilePicure, Environment.CurrentDirectory);
        }

        public Volunteer(string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password, string verklaringPdf)
            : base(name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            //TODO set id maybe not sure if needed in child class
            _reviews = new List<Review>();
            _perks = new List<string>();
            while (
                System.IO.File.Exists(Environment.CurrentDirectory + @"\\pf" + fileNameCountProfilePic.ToString() +
                                      ".png"))
            {
                fileNameCountProfilePic++;
            }
            System.IO.File.Copy(profilePicure, Environment.CurrentDirectory + @"\\pf" + fileNameCountProfilePic.ToString() + ".png");
            ProfilePicture = Environment.CurrentDirectory + @"\\pf" + fileNameCountProfilePic.ToString() + ".png";

            while (
                System.IO.File.Exists(Environment.CurrentDirectory + @"\\vog" + fileNameCountProfilePic.ToString() +
                                      ".png"))
            {
                fileNameCountVerklaring++;
            }

            System.IO.File.Copy(verklaringPdf, Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring.ToString() + ".png");
            _verklaringPdf = Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring.ToString() + ".png";
        }

        //methods
        public bool InviteToChat()
        {
            return false;
        }

    }
}
