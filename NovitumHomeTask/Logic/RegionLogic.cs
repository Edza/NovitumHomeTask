using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NovitumHomeTask.DataAccess;
using NovitumHomeTask.Model;

namespace NovitumHomeTask.Logic
{
    public class RegionLogic : IRegionLogic
    {
        private readonly IRegionRepository _repository;

        public RegionLogic(IRegionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Filters Novads list
        /// </summary>
        public IEnumerable<Novads> FilterNovadsList(FilterParameters filterParams)
        {
            List<Novads> novadsList = _repository.GetAllNovadsLoadedReadOnly();

            foreach (var novads in novadsList)
            {
                novads.PagastsList = this.FilterPagastsList(novads.Id, filterParams).ToList();
            }

            return novadsList.Where(novads => novads.PagastsList.Count > 0).ToList();
        }

        /// <summary>
        /// Filters Pagasts list
        /// </summary>
        public IEnumerable<Pagasts> FilterPagastsList(int novadsId, FilterParameters filterParams)
        {
            Novads givenNovads = _repository.GetAllNovadsLoadedReadOnly()
                .FirstOrDefault(novads => novads.Id == novadsId);

            if (givenNovads == null)
                throw new InvalidOperationException("Must pass novadsId.");

            List<Func<Polygon1km, bool>> predicates = this.GetFiltrationPredicates(filterParams);
            List<Pagasts> pagastsList = givenNovads.PagastsList;

            foreach(var pagasts in pagastsList)
            {
                pagasts.Polygon1kmList = this.ApplyFiltersOnPolygonList(predicates, pagasts.Polygon1kmList);
            }

            return pagastsList.Where(pagasts => pagasts.Polygon1kmList.Count > 0).ToList();
        }

        /// <summary>
        /// Filters Polygons lists
        /// </summary>
        public IEnumerable<Polygon1km> FilterPolygonList(int novadsId, int pagastsId, FilterParameters filterParams)
        {
            Novads givenNovads = _repository.GetAllNovadsLoadedReadOnly()
                .FirstOrDefault(novads => novads.Id == novadsId);

            if (givenNovads == null)
                throw new InvalidOperationException("Must pass novadsId.");

            Pagasts givenPagasts = givenNovads.PagastsList.FirstOrDefault(pagasts => pagasts.Id == pagastsId);

            if (givenPagasts == null)
                throw new InvalidOperationException("Must pass pagastsId.");

            List<Polygon1km> polygons = givenPagasts.Polygon1kmList;

            List<Func<Polygon1km, bool>> predicates = this.GetFiltrationPredicates(filterParams);
            return this.ApplyFiltersOnPolygonList(predicates, polygons);
        }

        /// <summary>
        /// Applies filters on a list
        /// </summary>
        private List<Polygon1km> ApplyFiltersOnPolygonList(List<Func<Polygon1km, bool>> filters, List<Polygon1km> polygons)
        {
            foreach (var filter in filters)
            {
                polygons = polygons.Where(filter).ToList(); // A bit of overhead here converting to list in a loop (this would be optimized in a real world project)
            }

            return polygons;
        }

        /// <summary>
        /// Generates a list of prediactes for filtering polygons
        /// </summary>
        private List<Func<Polygon1km, bool>> GetFiltrationPredicates(FilterParameters filter)
        {
            var predicates = new List<Func<Polygon1km, bool>>();

            if (filter.TotalPopulationMin != null)
            {
                predicates.Add(polygon => polygon.Info.TotalPopulation >= filter.TotalPopulationMin);
            }

            if (filter.ClientsMin != null)
            {
                predicates.Add(polygon => polygon.Info.Clients >= filter.ClientsMin);
            }

            if (filter.PotentialMin != null)
            {
                predicates.Add(polygon => polygon.Info.Potential >= filter.PotentialMin);
            }

            if (filter.MaleDensity != null)
            {
                predicates.Add(polygon => polygon.Info.MaleDensity == filter.MaleDensity);
            }

            if (filter.KidDensity != null)
            {
                predicates.Add(polygon => polygon.Info.KidDensity == filter.KidDensity);
            }

            if (filter.WorkAgeDensity != null)
            {
                predicates.Add(polygon => polygon.Info.WorkAgeDensity == filter.WorkAgeDensity);
            }

            if (filter.ElderlyDensity != null)
            {
                predicates.Add(polygon => polygon.Info.ElderlyDensity == filter.ElderlyDensity);
            }

            return predicates;
        }
    }
}
