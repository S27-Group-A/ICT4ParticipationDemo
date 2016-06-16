namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class Response
    {
        /// <summary>
        /// Gets or sets the responderid
        /// </summary>
        public int ResponderId { get; set; }
        /// <summary>
        /// gets or sets the requestid
        /// </summary>
        public int RequestId { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// gets or sets the date
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// gets or sets the volunteer
        /// </summary>
        public Account Volunteer { get; set; }
        /// <summary>
        /// gets or sets the responsedate
        /// </summary>
        public DateTime ResponseDate { get; set; }
        /// <summary>
        /// Gets or sets the responseid
        /// </summary>
        public int ResponseId { get; set; }

        /// <summary>
        /// Lege constructor
        /// </summary>
        public Response()
        {

        }

        /// <summary>
        /// Response constructor waarbij een gedeelte van de properties worden gevuld
        /// </summary>
        /// <param name="responderid"></param>
        /// <param name="RequestId"></param>
        /// <param name="description"></param>
        /// <param name="date"></param>
        public Response(int responderid, int RequestId, string description, DateTime date)
        {
            this.ResponderId = responderid;
            this.RequestId = RequestId;
            this.Description = description;
            this.Date = date;
        }

        /// <summary>
        /// Response constructor die word gebruikt bij het toevoegen
        /// </summary>
        /// <param name="volunteer"></param>
        /// <param name="description"></param>
        /// <param name="responseDate"></param>
        public Response(Account volunteer, string description, DateTime responseDate)
        {
            Volunteer = volunteer;
            Description = description;
            ResponseDate = responseDate;
        }

        /// <summary>
        /// adds the response to the database
        /// </summary>
        /// <param name="response"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool AddResponse(Response response, Request request)
        {
            return DatabaseManager.AddResponse(response, request);
        }
    }
}