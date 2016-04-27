//-----------------------------------------------------------------------
// <copyright file="VolunteerSystem.cs" company="S27A">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;

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
            this.PutUsersInCorrectList(this.GetAllUsers());
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


        public List<IUser> GetAllUsers()
        {
            return DatabaseManager.GetUsers();
        }

        public void PutUsersInCorrectList(List<IUser> users)
        {
            foreach (IUser iu in users)
            {
                if (iu is Volunteer)
                {
                    this.Volunteers.Add(iu as Volunteer);
                }
                if (iu is Patient)
                {
                    this.Patients.Add(iu as Patient);
                }
            }
        }
        /// <summary>
        /// Gets all the requests from all the patients and stores them in the list
        /// </summary>
        /// TODO This is a get use a return List<Requests>();
        public void GetAllRequests()
        {
            List<Request> tempR = null;
            foreach (Patient p in this.Patients)
            {
                tempR = DatabaseManager.GetRequests(p);
                p.Requests = tempR;
                foreach (Request r in tempR)
                {
                    Requests.Add(r);
                    foreach (Response resp in GetAllResponses(r))
                    {
                        r.Responses.Add(resp);
                    }
                }
                
            }
        }

        public List<Response> GetAllResponses(Request req)
        {
            return DatabaseManager.GetResponsesFromRequest(req);
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

        public void AddNewResponse(Request request, Volunteer volunteer, string text)
        {
            Response tempResponse = new Response(text, DateTime.Now, volunteer);
            DatabaseManager.AddResponse(volunteer, request, tempResponse);
            request.Responses.Add(tempResponse);
        }
    }
}
