using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SharpKml.Dom;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Polygon of 1km
    /// </summary>
    public class Polygon1km
    {
        /// <summary>
        /// Polygon id
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Bounding polygon
        /// </summary>
        /// <remarks>
        /// Not mapped as we would need to create a deeper structure with set Id keys for EF.
        /// </remarks>
        [NotMapped]
        public Geometry CoordinatesPolygon { get; set; }

        /// <summary>
        /// Quantitative info about polygon
        /// </summary>
        public Polygon1kmInfo Info { get; set; }
    }
}
