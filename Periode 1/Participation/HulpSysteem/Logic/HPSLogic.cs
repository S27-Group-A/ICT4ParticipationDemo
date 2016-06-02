using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;
using Participation.SharedModels;

namespace Participation.HulpSysteem.Logic
{
    public class HPSLogic
    {
        /// <summary>
        ///     Adds request with the parameters patient and request
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddRequest(Patient patient, Request request)
        {
            return DatabaseManager.AddRequest(patient, request);
            /*
            patient.Requests.Add(request);
            MessageBox.Show(request.Title + "is toegevoegd!");
            */
        }

        public bool AddReview(Volunteer volunteer, Patient patien, Review review)
        {
            return DatabaseManager.AddReview(volunteer, patien, review);
        }

        public List<string> GetPerk()
        {
            return DatabaseManager.GetPerks();
        }

        public List<IUser> GetUsers()
        {
            return DatabaseManager.GetUsers();
        }

        public List<Volunteer> GetVolunteers()
        {
            var volunteers = new List<Volunteer>();
            foreach (var v in GetUsers())
            {
                if (v.GetType() == typeof(Volunteer))
                    volunteers.Add(v as Volunteer);
            }
            return volunteers;
        }

        /// <summary>
        ///     Returns list of requests based on patient
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public List<Request> GetRequests(IUser patient)
        {
            return DatabaseManager.GetRequests(patient);
            //try
            //{
            //    throw new NotImplementedException();
            //}
            //catch
            //{
            //    MessageBox.Show("Database context not implement");
            //    return new List<Request>()
            //    {
            //        (new Request("Boswandeling", "Ik wil graag een boswandeling maken door het bos", new List<string>(),
            //            "Eindhoven", DateTime.Now, 1))
            //    };
            //}
        }
    }
}