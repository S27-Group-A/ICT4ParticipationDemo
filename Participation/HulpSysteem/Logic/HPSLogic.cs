using Participation.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Participation.InlogSysteem.Interfaces;

namespace Participation.HulpSysteem.Logic
{
    public class HPSLogic
    {
        public HPSLogic()
        {
        }

        public void AddRequest(Patient patient, Request request)
        {
            patient.Requests.Add(request);
            //TODO Add database context to add request to database
        }

        //TODO Implement this
        /*
    public List<Request> GetRequestsByUser(IUser user)
    {
        //TODO Add database context

        #region databaseless testing

        var requests = new List<Request>();
        requests.Add(new Request("Wandeling in het park", "Ik wil graag een wandeling in het park gaan maken.", new List<string>(), "Eindhove"));
        
        #endregion


    }
    */
}
}