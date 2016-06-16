// <copyright file="Request.cs" company="Ict4Participation">
//      Copyright (c) ICT4Rails. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
// <author>Sven Hendericks</author>
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
        /// Gets or sets the request id.
        /// </summary>
        public int RequestId { get; set; }

        /// <summary>
        /// Gets or sets the request description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the request location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the travel time in minutes
        /// </summary>
        public int TravelTime { get; set; }

        /// <summary>
        /// Gets or sets the request start date.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the request end date.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets how urgent the request is.
        /// </summary>
        public int Urgency { get; set; }

        /// <summary>
        /// Gets or sets how many volunteers this request requires.
        /// </summary>
        public int AmountOfVolunteers { get; set; }

        /// <summary>
        /// Gets or sets which skills this request requires.
        /// </summary>
        public List<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the kind of vehicle that is required for this request.
        /// </summary>
        public VehicleType VehicleType { get; set; }

        /// <summary>
        /// Gets or sets who is requesting help.
        /// </summary>
        public Patient Patient { get; set; }

        /// <summary>
        /// Gets or sets responses to the request.
        /// </summary>
        public List<Response> Responses { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The database ID for request</param>
        public Request()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        public Request(int requestId)
        {
            this.RequestId = requestId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="requestId">The database ID for request.</param>
        /// <param name="description">The request's description.</param>
        /// <param name="location">the request's location.</param>
        /// <param name="travelTime">the possible travel time.</param>
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
        /// <param name="travelTime">the possible travel time.</param>
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
        public void AddResponse(Response response)
        {
           this.Responses.Add(response);
        }

        /// <summary>
        /// Adds a new request to the database.
        /// </summary>
        /// <param name="request">The request that will be added to the database.</param>
        /// <returns>A true of false depending on the database method success</returns>
        public bool AddRequest(Request request)
        {
            return DatabaseManager.AddRequest(request);
		}
    }
}