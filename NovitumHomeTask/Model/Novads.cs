using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using SharpKml.Dom;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Region of Novads
    /// </summary>
    [Serializable]
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
        /// Lists of Pagasts inside this region
        /// </summary>
        public List<Pagasts> PagastsList { get; set; }

        /// <summary>
        /// Sum of all population in this region
        /// </summary>
        public int SumTotalPopulation
        {
            get
            {
                return this.PagastsList.Sum(p => p.SumTotalPopulation);
            }
        }

        /// <summary>6
        /// Sum of all clients in this region
        /// </summary>
        public int SumTotalClients
        {
            get
            {
                return this.PagastsList.Sum(p => p.SumTotalClients);
            }
        }

        /// <summary>
        /// Sum of all population in this region
        /// </summary>
        public int SumTotalPotential
        {
            get
            {
                return this.PagastsList.Sum(p => p.SumTotalPotential);
            }
        }

        /// <summary>
        /// Region bounding coordinates
        /// </summary>
        /// <remarks>
        /// Not mapped as we would need to create a deeper structure with set Id keys for EF.
        /// </remarks>
        [NotMapped]
        [JsonIgnore]
        [field:NonSerialized]
        public Geometry CoordinatesPolygon { get; set; }
    }
}
