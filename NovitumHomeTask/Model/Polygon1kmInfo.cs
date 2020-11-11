using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Detailed polygon info
    /// </summary>
    [Serializable]
    public class Polygon1kmInfo
    {
        /// <summary>
        /// Polygon 1km ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Total population
        /// </summary>
        public int TotalPopulation { get; set; }

        /// <summary>
        /// Center lattitude
        /// </summary>
        public double CenterLat { get; set; }

        /// <summary>
        /// Center longitude
        /// </summary>
        public double CenterLong { get; set; }

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
        /// Penetration
        /// </summary>
        public string Penetration { get; set; }

        /// <summary>
        /// Clients
        /// </summary>
        public int Clients { get; set; }

        /// <summary>
        /// Potential
        /// </summary>
        public int Potential { get; set; }

        /// <summary>
        /// Penetration bin
        /// </summary>
        public string PenetrationBin { get; set; }
    }

    public class Polygon1kmInfoClassMap : ClassMap<Polygon1kmInfo>
    {
        public Polygon1kmInfoClassMap()
        {
            Map(m => m.Id).Name("km_grid");
            Map(m => m.TotalPopulation).Name("km_total_iedzivotaji");
            Map(m => m.CenterLat).Name("lat");
            Map(m => m.CenterLong).Name("long");
            Map(m => m.MaleDensity).Name("Male_Density_gr");
            Map(m => m.KidDensity).Name("Kid_Density_gr");
            Map(m => m.WorkAgeDensity).Name("Work_Age_Density_gr");
            Map(m => m.ElderlyDensity).Name("Elderly_Density_gr");
            Map(m => m.Penetration).Name("Penetration");
            Map(m => m.Clients).Name("Clients");
            Map(m => m.Potential).Name("Potencial");
            Map(m => m.PenetrationBin).Name("Penetration_bin");
        }
    }
}