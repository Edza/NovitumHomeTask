using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovitumHomeTask.Model;

namespace NovitumHomeTask.Logic
{
    public class RegionLogic : IRegionLogic
    {
        /// <summary>
        /// Filters Novads list
        /// </summary>
        public IEnumerable<Novads> FilterNovadsList(FilterParameters filterParams)
        {
            return null;
        }

        /// <summary>
        /// Filters Pagasts list
        /// </summary>
        public IEnumerable<Pagasts> FilterPagastsList(int novadsId, FilterParameters filterParams)
        {
            return null;

        }

        /// <summary>
        /// Filters Polygons lists
        /// </summary>
        public IEnumerable<Polygon1km> FilterPolygonList(int novadsId, int pagastsId, FilterParameters filterParams)
        {
            return null;

        }
    }
}
