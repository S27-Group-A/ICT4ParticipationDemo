//-----------------------------------------------------------------------
// <copyright file="VolunteerSystem.cs" company="S27A">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace Participation.VrijwilligersSysteem.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Participation.SharedModels;

    public class VolunteerSystem
    {
        // constructor
        public VolunteerSystem()
        {
            this.Volunteers = new List<Volunteer>();
            this.Requests = new List<Request>();
            this.Patients = new List<Patient>();
            Patient test1 = new Patient("Sjeng", "sven@gmail.com", "Goeie hulpverlener enzo", DateTime.Now, "-", "Grathem", "06123456789", GenderEnum.Male, "pw");
            this.Patients.Add(test1);
            test1.AddRequest("Huiswerk", "Help me!!", null, "Grathem", DateTime.Now, 0);
            test1.AddRequest("Carnaval", "Die hoor je en die zie je overal.", null, "Grashoek", DateTime.Now, 1);
            this.GetAllRequests();
        }

        // properties

        /// <summary>
        /// Gets the list of patients
        /// </summary>
        public List<Patient> Patients { get; private set; }

        /// <summary>
        /// Gets the list of volunteers
        /// </summary>
        public List<Volunteer> Volunteers { get; private set; }

        /// <summary>
        /// Gets the List of requests
        /// </summary>
        public List<Request> Requests { get; private set; }

        /// <summary>
        /// Gets all the requests from all the patients and stores them in the list
        /// </summary>
        public void GetAllRequests()
        {
            foreach (Patient p in this.Patients)
            {
                if (p.Requests.Count > 0)
                {
                    foreach (Request r in p.Requests)
                    {
                        this.Requests.Add(r);
                    }
                }
            }
        }
        
        /// <summary>
        /// Gets the patient object from the request object
        /// </summary>
        /// <param name="request">Input request</param>
        /// <returns>The patient who the request belongs to</returns>
        public Patient GetPatientFromRequest(Request request)
        {
            foreach (Patient p in this.Patients)
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
