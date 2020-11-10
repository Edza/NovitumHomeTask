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
    /// Region of Novads
    /// </summary>
    public class Novads
    {
        /// <summary>
        /// Region id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Region name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Region bounding coordinates
        /// </summary>
        /// <remarks>
        /// Not mapped as we would need to create a deeper structure with set Id keys for EF.
        /// </remarks>
        [NotMapped]
        public Geometry CoordinatesPolygon { get; set; }

        /// <summary>
        /// Lists of Pagasts inside this region
        /// </summary>
        public List<Pagasts> PagastsList { get; set; }

        // Kopsummu lauki: km_total_iedzivotaji, Clients, Potential
    }
}
