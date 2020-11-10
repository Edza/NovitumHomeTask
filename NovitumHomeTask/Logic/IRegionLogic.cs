using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovitumHomeTask.Model;

namespace NovitumHomeTask.Logic
{
    /// <summary>
    /// Logic for filtering novads and pagasts
    /// </summary>
    public interface IRegionLogic
    {
        /// <summary>
        /// Filters Novads list
        /// </summary>
        IEnumerable<Novads> FilterNovadsList(FilterParameters filterParams);

        /// <summary>
        /// Filters Pagasts list
        /// </summary>
        IEnumerable<Pagasts> FilterPagastsList(int novadsId, FilterParameters filterParams);

        /// <summary>
        /// Filters Polygons lists
        /// </summary>
        IEnumerable<Polygon1km> FilterPolygonList(int novadsId, int pagastsId, FilterParameters filterParams);
    }
}
