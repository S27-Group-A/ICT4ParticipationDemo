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
        public List<Review> _reviews { get; set; }
        public List<string> _perks { get; set; }
        public string _verklaringPdf { get; set; }
        //public static int fileNameCountVerklaring = 0;
        //public static int fileNameCountProfilePic = 0;
        public bool _isAdmin { get; set; }

        //constructors

        public Volunteer(string name, string email, string description, DateTime birthday, string profilePicture, string location, string phoneNumber, GenderEnum gender, string password, List<Meeting> meetings, List<string> perks, bool adminrights)
            : base(name, email, description, birthday, profilePicture, location, phoneNumber, gender, password, ban, bantimeindays)
        {
            _reviews = new List<Review>();
            _perks = perks;
            _verklaringPdf = null;
            _isAdmin = adminrights;
        }

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
            string phoneNumber, GenderEnum gender, string password, string verklaringPdf, bool isAdmin)
            : base(id, name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            _reviews = new List<Review>();
            _perks = new List<string>();
            //stem.IO.File.Copy(profilePicure, Environment.CurrentDirectory);
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

            AddVerklaring(verklaringPdf);
        }

        //methods
        public bool InviteToChat()
        {
            return false;
        }

        public List<string> GetPerks()
        {
            return _perks;
        }

        public void AddPerk(string perk)
        {
            if (perk != "" || perk != " ")
            {
                this._perks.Add(perk);
            }
        }

        public void AddVerklaring(string path)
        {
            while (
                System.IO.File.Exists(Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring.ToString() +
                                      ".png"))
            {
                fileNameCountVerklaring++;
            }

            System.IO.File.Copy(path, Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring.ToString() + ".png");
            _verklaringPdf = Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring.ToString() + ".png";
        }

        public string GetFileNameVog()
        {
            throw new NotImplementedException();
        }
    }
}
