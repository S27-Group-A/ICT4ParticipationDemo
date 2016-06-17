// <copyright file="VehicleType.cs" company="Ict4Participation">
//      Copyright (c) Ict4Participation. All rights reserved.
// </copyright>
namespace Participation_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The type of vehicle which a request might require.
    /// </summary>
    public class VehicleType
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="VehicleType"/> class.
        /// </summary>
        /// <param name="id">Database id</param>
        /// <param name="description">Vehicle type.</param>
        public VehicleType(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }
    }
}