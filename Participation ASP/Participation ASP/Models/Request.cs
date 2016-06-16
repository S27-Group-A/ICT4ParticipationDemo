
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Model used for requests from a patient.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Requestid from the database.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Request description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Request location.
        /// </summary>
        public string Location { get; set; }
        
        /// <summary>
        /// Traveltime in minutes
        /// </summary>
        public int TravelTime { get; set; }

        /// <summary>
        /// Request start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Request end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// How urgent the request is.
        /// </summary>
        public int Urgency { get; set; }

        /// <summary>
        /// How many volunteers this request requires.
        /// </summary>
        public int AmountOfVolunteers { get; set; }

        /// <summary>
        /// Which skills this request requires.
        /// </summary>
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// What kind of vehicle is required for this request.
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// Who is requesting help.
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Responses to the request.
        /// </summary>
        public List<Response> Responses { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The database ID for request</param>
        public Request(int requestId)
        {
            RequestId = requestId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The database ID for request.</param>
        /// <param name="description">The request's description.</param>
        /// <param name="location">the request's location.</param>
        /// <param name="travelTime">the possible traveltime.</param>
        /// <param name="startDate">The start date of the request.</param>
        /// <param name="endDate">The end date of the request.</param>
        /// <param name="urgency">How urgent is the request.</param>
        /// <param name="amountOfVolunteers">The amount of volunteers required.</param>
        /// <param name="skills">The skills for this request.</param>
        /// <param name="vehicleType">The vehicle needed for this request.</param>
        /// <param name="patient">The patient calling for a request.</param>
        /// <param name="responses">Responses to this request.</param>
        public Request(int requestId, string description, string location, int travelTime, DateTime startDate, DateTime endDate, int urgency, int amountOfVolunteers, List<Skill> skills, VehicleType vehicleType, Patient patient, List<Response> responses)
        {
            this.RequestId = requestId;
            this.Description = description;
            this.Location = location;
            this.TravelTime = travelTime;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Urgency = urgency;
            this.AmountOfVolunteers = amountOfVolunteers;
            this.Skills = skills;
            this.VehicleType = vehicleType;
            this.Patient = patient;
            this.Responses = responses;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The database ID for request.</param>
        /// <param name="description">The request's description.</param>
        /// <param name="location">the request's location.</param>
        /// <param name="travelTime">the possible traveltime.</param>
        /// <param name="startDate">The start date of the request.</param>
        /// <param name="endDate">The end date of the request.</param>
        /// <param name="urgency">How urgent is the request.</param>
        /// <param name="amountOfVolunteers">The amount of volunteers required.</param>
        /// <param name="skills">The skills for this request.</param>
        /// <param name="vehicleType">The vehicle needed for this request.</param>
        /// <param name="patient">The patient calling for a request.</param>
        public Request(int requestId, string description, string location, int travelTime, DateTime startDate, DateTime endDate, int urgency, int amountOfVolunteers, List<Skill> skills, VehicleType vehicleType, Patient patient)
        {
            this.RequestId = requestId;
            this.Description = description;
            this.Location = location;
            this.TravelTime = travelTime;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Urgency = urgency;
            this.AmountOfVolunteers = amountOfVolunteers;
            this.Skills = skills;
            this.VehicleType = vehicleType;
            this.Patient = patient;
        }

        /// <summary>
        /// Method used to store the response in the database.
        /// </summary>
        /// <param name="response">The response object that will be stored in the database.</param>
        /// <param name="request">The request object that will be stored in the database.</param>
        public bool AddResponse(Response response, Request request)
        {
            return DatabaseManager.AddResponse(response, request);
        }

        /// <summary>
        /// Adds a new request to the database.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>A true of false depending on the database method succes</returns>
        public bool AddRequest(Request request)
        {
            return DatabaseManager.AddRequest(request);
		}
    }
}