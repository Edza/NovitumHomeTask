using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Object which will be created from request URI parameters. For better filtring most fields would need Min, Max and Exact versions.
    /// We would also need to add data types for Penetration and PenetrationBin.
    /// For filtring to be useful, this objects needs to be well thought out and versatile.
    /// </summary>
    public class FilterParameters
    {
        /// <summary>
        /// Total population minimum
        /// </summary>
        public int TotalPopulationMin { get; set; }

        /// <summary>
        /// Male density
        /// </summary>
        public string MaleDensity { get; set; }

        /// <summary>
        /// Kid density
        /// </summary>
        public string KidDensity { get; set; }

        /// <summary>
        /// Work age density
        /// </summary>
        public string WorkAgeDensity { get; set; }

        /// <summary>
        /// Elderly density
        /// </summary>
        public string ElderlyDensity { get; set; }

        /// <summary>
        /// Clients minimum
        /// </summary>
        public int ClientsMin { get; set; }

        /// <summary>
        /// Potential minimum
        /// </summary>
        public int PotentialMin { get; set; }

        /// <summary>
        /// Penetration
        /// </summary>
        /// <remarks>
        /// IMPORTANT! In this demo filtration by this not created.
        /// </remarks>
        public string Penetration { get; set; }

        /// <summary>
        /// Penetration bin
        /// </summary>
        /// <remarks>
        /// IMPORTANT! In this demo filtration by this not created.
        /// </remarks>
        public string PenetrationBin { get; set; }
    }
}
