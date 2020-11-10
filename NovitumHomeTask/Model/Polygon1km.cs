using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public string Id { get; set; }

        /// <summary>
        /// Bounding polygon
        /// </summary>
        public object CoordinatesPolygon { get; set; }

        /// <summary>
        /// Quantitative info about polygon
        /// </summary>
        public Polygon1kmInfo Info { get; set; }
    }
}
