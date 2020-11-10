using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper.Configuration;

namespace NovitumHomeTask.Model
{
    /// <summary>
    /// Mapping class for building Novads/Pagasts relations
    /// </summary>
    public class NovadsPagasts
    {
        /// <summary>
        /// Novads region code
        /// </summary>
        public int NovadsId { get; set; }

        /// <summary>
        /// Novads region name
        /// </summary>
        public string NovadsName { get; set; }

        /// <summary>
        /// Pagasts region code
        /// </summary>
        public int PagastsId { get; set; }

        /// <summary>
        /// Pagasts region name
        /// </summary>
        public string PagastsName { get; set; }
    }

    public class NovadsPagastsClassMap : ClassMap<NovadsPagasts>
    {
        public NovadsPagastsClassMap()
        {
            Map(m => m.NovadsId).Name("novada_kods");
            Map(m => m.PagastsName).Name("pagasts");
            Map(m => m.PagastsId).Name("pagasta_kods");
            Map(m => m.NovadsName).Name("novada_nosaukums");
        }
    }

}
