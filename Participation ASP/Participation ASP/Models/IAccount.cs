using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation_ASP.Models
{
    public interface IAccount
    {
        int AccountId { get; set; }

        string Username { get; set; }

        string Password { get; set; }

        string Email { get; set; }

        string Name { get; set; }

        int Phone { get; set; }

        DateTime DateCancellation { get; set; }

        string Address { get; set; }

        string Location { get; set; }

        bool HasCar { get; set; }

        bool HasDriversLicense { get; set; }

        string RFID { get; set; }

        bool Banned { get; set; }

        bool Unban { get; set; }

        bool Enabled { get; set; }

        bool IsAdmin { get; set; }

        IAccount LoginAccount(IAccount account);
    }
}
