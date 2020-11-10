using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using NovitumHomeTask.Model;
using SharpKml.Dom;
using SharpKml.Engine;

namespace NovitumHomeTask.Logic
{
    public class DataImportLogic
    {
        public void CreateModelFromDisk()
        {
            var polygonInfos = new List<Polygon1kmInfo>();
            var novadsPagastsMapping = new List<NovadsPagasts>();
            var pagastsPolygon1kmMapping = new List<PagastsPolygon1km>();

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\1km_filtri.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<Polygon1kmInfoClassMap>();
                polygonInfos = csv.GetRecords<Polygon1kmInfo>().ToList();
            }

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\nov_pag_mappings.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<NovadsPagastsClassMap>();
                novadsPagastsMapping = csv.GetRecords<NovadsPagasts>().ToList();
            }

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\pagasta_km_mappings.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<PagastsPolygon1kmClassMap>();
                pagastsPolygon1kmMapping = csv.GetRecords<PagastsPolygon1km>().ToList();
            }

            var polygons1km = new List<Polygon1km>();
            var novadsList = new List<Novads>();
            var pagastsList = new List<Pagasts>();

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\1km_lv.kml"))
            {
                KmlFile file = KmlFile.Load(reader);

                Kml kml = file.Root as Kml;
                if (kml != null)
                {
                    foreach (var placemark in kml.Flatten().OfType<Placemark>())
                    {
                        var polygonInfo = polygonInfos.FirstOrDefault(x => x.Id == placemark.Name);

                        if (polygonInfo == null)
                            continue;

                        polygons1km.Add(new Polygon1km()
                        {
                            Id = placemark.Name,
                            CoordinatesPolygon = placemark.Geometry,
                            Info = polygonInfo,
                        });
                    }
                }
            }

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\pagasti_pol.kml"))
            {
                KmlFile file = KmlFile.Load(reader);

                Kml kml = file.Root as Kml;
                if (kml != null)
                {
                    foreach (var placemark in kml.Flatten().OfType<Placemark>())
                    {
                        // Transform from mapping structure to relational structure
                        var polygonsInThisPagasts = pagastsPolygon1kmMapping.Where(mappingDto => mappingDto.PagastsId == int.Parse(placemark.Name))
                            .Select(mappingDto => polygons1km.First(polygon1km => polygon1km.Id == mappingDto.Polygon1kmId))
                            .ToList();

                        pagastsList.Add(new Pagasts()
                        {
                            Id = int.Parse(placemark.Name),
                            Name = novadsPagastsMapping.First(p => p.PagastsId == int.Parse(placemark.Name)).PagastsName,
                            CoordinatesPolygon = placemark.Geometry,
                            Polygon1kmList = polygonsInThisPagasts,
                        });
                    }
                }
            }

            using (var reader = new StreamReader(@"C:\Users\edza\Desktop\NovitumMd\Assignment_Novitum_data\novadi_pol.kml"))
            {
                KmlFile file = KmlFile.Load(reader);

                Kml kml = file.Root as Kml;
                if (kml != null)
                {
                    foreach (var placemark in kml.Flatten().OfType<Placemark>())
                    {
                        // Transform from mapping structure to relational structure
                        var pagastsInThisNovads = novadsPagastsMapping.Where(mappingDto => mappingDto.NovadsId == int.Parse(placemark.Name))
                            .Select(mappingDto => pagastsList.FirstOrDefault(pagasts => pagasts.Id == mappingDto.PagastsId))
                            .Where(item => item != null) // Incomplete list of Pagasts, some that are in mapping are not in our data
                            .ToList();

                        novadsList.Add(new Novads()
                        {
                            Id = int.Parse(placemark.Name),
                            Name = placemark.Description.Text,
                            CoordinatesPolygon = placemark.Geometry,
                            PagastsList = pagastsInThisNovads,
                        });
                    }
                }
            }
        }
    }
}
