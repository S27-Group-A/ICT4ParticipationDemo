using Participation.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Participation.HulpSysteem.Logic
{
    public class HPSLogic
    {
        public void AddRequest(Patient patient, Request request)
        {
            patient.requests.Add(request);
            //TODO Add database context to add request to database
        }
    }
}
