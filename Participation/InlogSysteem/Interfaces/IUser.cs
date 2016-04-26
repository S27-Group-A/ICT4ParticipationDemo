using System;
using System.Collections.Generic;
using Participation.SharedModels;

namespace Participation.InlogSysteem.Interfaces
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Description { get; set; }
        DateTime Birthday { get; set; }
        string ProfilePicture { get; set; }
        string Location { get; set; }
        string PhoneNumber { get; set; }
        GenderEnum Gender { get; set; }
        string Password { get; set; }
        List<Meeting> Meetings { get; set; }
        int Ban { get; set; }
        DateTime Unban { get; set; }

    }
}