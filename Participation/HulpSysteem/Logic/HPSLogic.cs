using Participation.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Participation.InlogSysteem.Interfaces;

namespace Participation.HulpSysteem.Logic
{
    public class HPSLogic
    {
        public HPSLogic()
        {
        }

        public bool AddRequest(Patient patient, Request request)
        {
            DatabaseManager.AddRequest();
            /*
            patient.Requests.Add(request);
            MessageBox.Show(request.Title + "is toegevoegd!");
            */
        }

        public List<Request> GetRequests(IUser patient)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch
            {
                MessageBox.Show("Database context not implement");
                return new List<Request>()
                {
                    (new Request("Boswandeling", "Ik wil graag een boswandeling maken door het bos", new List<string>(),
                        "Eindhoven", DateTime.Now, 1))
                };
            }
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