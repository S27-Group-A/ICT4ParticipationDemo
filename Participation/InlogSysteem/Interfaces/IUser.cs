using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;

namespace Participation.InlogSysteem.Interfaces
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Description { get; set; }
        DateTime Birthday { get; set; }
        string ProfilePicture { get; set; }
        string Location { get; set; }
        string PhoneNumber { get; set; }
        GenderEnum Gender { get; set; }
        string Password { get; set; }
        List<Meeting> meetings { get; set; }
    }
}
