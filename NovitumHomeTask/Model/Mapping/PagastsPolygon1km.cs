using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Mapping class for building pagasts/polygon relations
    /// </summary>
    public class PagastsPolygon1km
    {
        /// <summary>
        /// Polygon 1km region Id
        /// </summary>
        public string Polygon1kmId { get; set; }

        /// <summary>
        /// Pagasts region Id
        /// </summary>
        public int PagastsId { get; set; }
    }

    public class PagastsPolygon1kmClassMap : ClassMap<PagastsPolygon1km>
    {
        public PagastsPolygon1kmClassMap()
        {
            Map(m => m.Polygon1kmId).Name("km_grid");
            Map(m => m.PagastsId).Name("pagasta_kods");
        }
    }

}
