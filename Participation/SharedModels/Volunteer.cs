using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Participation.SharedModels
{
    public class Volunteer : User
    {
        //properties
        public List<Review> reviews { get; set; }
        public List<string> perks { get; set; }
        private static int fileNameCountVerklaring = 0;
        private static int fileNameCountProfilePic = 0;
        public string verklaringPdf { get; set; }
        public bool isAdmin { get; set; }
        //public static int fileNameCountVerklaring = 0;
        //public static int fileNameCountProfilePic = 0;


        //constructors
        public Volunteer(int id, string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password, string verklaringPdf, bool isAdmin)
            : base(id, name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            this.reviews = new List<Review>();
            this.perks = new List<string>();
            this.verklaringPdf = verklaringPdf;
            this.isAdmin = isAdmin;
            if (string.IsNullOrEmpty(profilePicure))
                System.IO.File.Copy(profilePicure, Environment.CurrentDirectory);
        }

        public Volunteer(string name, string email, string description,
            DateTime birthday, string profilePicure, string location,
            string phoneNumber, GenderEnum gender, string password, string verklaringPdf, bool isAdmin)
            : base(name, email, description, birthday, profilePicure, location, phoneNumber, gender, password)
        {
            this.reviews = new List<Review>();
            this.perks = new List<string>();
            this.verklaringPdf = verklaringPdf;
            this.isAdmin = isAdmin;
            if (string.IsNullOrEmpty(profilePicure))
                System.IO.File.Copy(profilePicure, Environment.CurrentDirectory);
        }


        /*
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
    */


        //methods
        public bool InviteToChat()
        {
            return false;
        }

        public List<string> GetPerks()
        {
            return perks;
        }

        public void AddPerk(string perk)
        {
            if (perk != "" || perk != " ")
            {
                this.perks.Add(perk);
            }
        }

        public void AddVerklaring(string path)
        {
            while (
                System.IO.File.Exists(Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring +
                                      ".png"))
            {
                fileNameCountVerklaring++;
            }

            System.IO.File.Copy(path, Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring + ".png");
            verklaringPdf = Environment.CurrentDirectory + @"\\vog" + fileNameCountVerklaring + ".png";
        }

        public string GetFileNameVog()
        {
            throw new NotImplementedException();
        }

        public List<Meeting> MeetingsWithStatus(int status)
        {
            List<Meeting> tempMeetings = null;
            foreach (Meeting m in Meetings)
            {
                if (m.Status == status)
                {
                    tempMeetings.Add(m);
                }
            }
            return tempMeetings;
        } 

    }
}
