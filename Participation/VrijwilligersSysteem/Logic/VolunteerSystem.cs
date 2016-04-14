using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.SharedModels;

namespace Participation.VrijwilligersSysteem.Logic
{
    public class VolunteerSystem
    {
        //properties
        public List<Volunteer> Volunteers { get; set; }

        //constructor
        public VolunteerSystem()
        {
            Volunteers = new List<Volunteer>();
        }
    }
}
