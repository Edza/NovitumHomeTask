using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Region of Novads
    /// </summary>
    public class Novads
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
        /// Lists of Pagasts inside this region
        /// </summary>
        public List<Pagasts> PagastsList { get; set; }

        // Kopsummu lauki: km_total_iedzivotaji, Clients, Potential
    }
}
