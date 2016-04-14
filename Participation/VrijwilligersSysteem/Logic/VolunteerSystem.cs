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
        public List<Patient> Patients { get; set; }
        public List<Volunteer> Volunteers { get; set; }

        public List<Request> Requests { get; set; }

        //constructor
        public VolunteerSystem()
        {
            Volunteers = new List<Volunteer>();
            Requests = new List<Request>();
            Patients = new List<Patient>();
            Patient test1 = new Patient("Sven", "sven@spetter.nl", "Trotste golden retriever eigenaar", DateTime.Now, "-", "Grathem", "06123466789", GenderEnum.Male);
            Patients.Add(test1);
            test1.AddRequest("Huiswerk", "Help me!!", null, "Grathem", DateTime.Now, 0);
            test1.AddRequest("Carnaval", "Die hoor je en die zie je overal.", null, "Grashoek", DateTime.Now, 0);
            GetAllRequests();
        }

        public void GetAllRequests()
        {
            foreach (Patient p in Patients)
            {
                if (p.Requests.Count > 0)
                {
                    foreach (Request r in p.Requests)
                    {
                        Requests.Add(r);
                    }
                }
            }
        }

        public Patient GetPatientFromRequest(Request request)
        {
            foreach (Patient p in Patients)
            {
                foreach (Request r in p.Requests)
                {
                    if (r == request)
                    {
                        return p;
                    }
                }
            }
            return null;
        }
    }
}
