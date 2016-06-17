// <copyright file="Review.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
// <author>Sander Koch</author>
// <author> Tom Ruijs</author>
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// Review of a volunteer.
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Gets or sets the review id.
        /// </summary>
        public int ReviewId { get; set; }

        /// <summary>
        /// Gets or sets the request which triggered the review.
        /// </summary>
        public Request Request { get; set; }

        /// <summary>
        /// Gets or sets the rating for the review.
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets the comment for the review.
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="reviewId">The review id.</param>
        /// <param name="request">the request which earned this review.</param>
        /// <param name="rating">Review rating.</param>
        /// <param name="comment">Review comment.</param>
        public Review(int reviewId, Request request, int rating, string comment)
        {
            this.ReviewId = reviewId;
            this.Request = request;
            this.Rating = rating;
            this.Comment = comment;
        }
    }
}