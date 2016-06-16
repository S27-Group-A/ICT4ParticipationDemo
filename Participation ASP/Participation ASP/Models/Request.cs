using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Participation_ASP.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        /// <summary>
        /// Traveltime in minutes
        /// </summary>
        public int TravelTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Urgency { get; set; }
        public int AmountOfVolunteers { get; set; }
        public List<Skill> Skills { get; set; }
        public VehicleType VehicleType { get; set; }
        public Patient Patient { get; set; }
        public List<Response> Responses { get; set; }

        public Request(int requestId)
        {
            RequestId = requestId;
        }

        public Request(int requestId, string description, string location, int travelTime, DateTime startDate, DateTime endDate, int urgency, int amountOfVolunteers, List<Skill> skills, VehicleType vehicleType, Patient patient, List<Response> responses)
        {
            RequestId = requestId;
            Description = description;
            Location = location;
            TravelTime = travelTime;
            StartDate = startDate;
            EndDate = endDate;
            Urgency = urgency;
            AmountOfVolunteers = amountOfVolunteers;
            Skills = skills;
            VehicleType = vehicleType;
            Patient = patient;
            Responses = responses;
        }


        public void AddResponse(Response response)
        {
            Responses.Add(response);
        }

        public bool AddRequest(Request request)
        {
            return DatabaseManager.AddRequest(request);
		}
		
        public Request(int requestId, string description, string location, int travelTime, DateTime startDate, DateTime endDate, int urgency, int amountOfVolunteers, List<Skill> skills, VehicleType vehicleType, Patient patient)
        {
            RequestId = requestId;
            Description = description;
            Location = location;
            TravelTime = travelTime;
            StartDate = startDate;
            EndDate = endDate;
            Urgency = urgency;
            AmountOfVolunteers = amountOfVolunteers;
            Skills = skills;
            VehicleType = vehicleType;
            Patient = patient;
		}

        
    }
}