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
    /// Region of Pagasts
    /// </summary>
    public class Pagasts
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
        /// List of 1km polygons inside this Pagasts
        /// </summary>
        public List<Polygon1km> Polygon1kmList { get; set; }

        /// <summary>
        /// Sum of all population in this region
        /// </summary>
        public int SumTotalPopulation
        {
            get
            {
                return this.Polygon1kmList.Sum(poly => poly.Info.TotalPopulation);
            }
        }

        /// <summary>
        /// Sum of all clients in this region
        /// </summary>
        public int SumTotalClients
        {
            get
            {
                return this.Polygon1kmList.Sum(poly => poly.Info.Clients);
            }
        }

        /// <summary>
        /// Sum of all population in this region
        /// </summary>
        public int SumTotalPotential
        { 
            get
            {
                return this.Polygon1kmList.Sum(poly => poly.Info.Potential);
            }
        }

        /// <summary>
        /// Region bounding coordinates
        /// </summary>
        /// <remarks>
        /// Not mapped as we would need to create a deeper structure with set Id keys for EF.
        /// </remarks>
        [NotMapped]
        public Geometry CoordinatesPolygon { get; set; }
    }
}
