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
        public DateTime TimeStamp { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Urgency { get; set; }
        public int AmountOfVolunteers { get; set; }
        public List<Skill> Skills { get; set; }
        public VehicleType VehicleType { get; set; }
        public Account Patient { get; set; }

        public Request(int requestId, string description, string location, DateTime timeStamp, DateTime startDate, DateTime endDate, int urgency, int amountOfVolunteers, List<Skill> skills, VehicleType vehicleType, Account patient)
        {
            RequestId = requestId;
            Description = description;
            Location = location;
            TimeStamp = timeStamp;
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