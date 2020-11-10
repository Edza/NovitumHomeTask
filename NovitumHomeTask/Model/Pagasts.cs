using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Region of Pagasts
    /// </summary>
    public class Pagasts
    {
        /// <summary>
        /// Region id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Region name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Region bounding coordinates
        /// </summary>
        public object CoordinatesPolygon { get; set; }

        /// <summary>
        /// List of 1km polygons inside this Pagasts
        /// </summary>
        public List<Polygon1km> Polygon1kmList { get; set; }

        // Kopsummu lauki: km_total_iedzivotaji, Clients, Potential
    }
}
