namespace NovitumHomeTask.Tests.Controllers
{
    using NovitumHomeTask.Controllers;
    using System;
    using NUnit.Framework;
    using NovitumHomeTask.Logic;
    using NovitumHomeTask.Model;
    using Moq;
    using System.Collections.Generic;
    using System.Web.Http.Results;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;

    /// <summary>
    /// Created basic tests for controller here as an example. In real world project would need to cover logic and data access as well, as well as more fully. :)
    /// </summary>
    [TestFixture]
    public class RegionControllerTests
    {
        private RegionController _target;
        private Mock<IRegionLogic> _regionLogicMock;
        private IRegionLogic _regionLogic;

        [SetUp]
        public void SetUp()
        {
            _regionLogicMock = new Mock<IRegionLogic>();
            _regionLogic = _regionLogicMock.Object;
            _target = new RegionController(_regionLogic);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new RegionController(_regionLogic);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CanCallFilterNovadsList()
        {
            var filterParams = new FilterParameters { TotalPopulationMin = 1103198633, ClientsMin = 637576999, PotentialMin = 1532929098, MaleDensity = "TestValue1368770008", KidDensity = "TestValue1555459913", WorkAgeDensity = "TestValue1100357283", ElderlyDensity = "TestValue1506066524", Penetration = "TestValue1211357128", PenetrationBin = "TestValue1203882965" };
            List<Novads> novadsList = new List<Novads>()
            {
                new Novads(),
            };

            _regionLogicMock.Setup(x => x.FilterNovadsList(It.IsAny<FilterParameters>()))
                .Returns(novadsList);

            var result = _target.FilterNovadsList(filterParams);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(OkObjectResult)));
            Assert.That((result as ObjectResult).Value, Is.EqualTo(novadsList));
        }

        [Test]
        public void CanCallFilterPagastsList()
        {
            var novadsId = 1677134498;
            var filterParams = new FilterParameters { TotalPopulationMin = 100 };
            List<Pagasts> pagastsList = new List<Pagasts>()
            {
                new Pagasts(),
            };

            _regionLogicMock.Setup(x => x.FilterPagastsList(novadsId, It.IsAny<FilterParameters>()))
                .Returns(pagastsList);

            var result = _target.FilterPagastsList(novadsId, filterParams);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(OkObjectResult)));
            Assert.That((result as ObjectResult).Value, Is.EqualTo(pagastsList));
        }

        [Test]
        public void CannotCallFilterPagastsListWithNegativeTotalPopulation()
        {
            var novadsId = 1677134498;
            var filterParams = new FilterParameters { TotalPopulationMin = -99 }; // Bad parameter

            _regionLogicMock.Setup(x => x.FilterPagastsList(novadsId, It.IsAny<FilterParameters>()))
                .Returns(new List<Pagasts>());

            var result = _target.FilterPagastsList(novadsId, filterParams);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(BadRequestObjectResult)));
        }

        [Test]
        public void CanCallFilterPolygonList()
        {
            var novadsId = 1922425146;
            var pagastsId = 903026255;
            var filterParams = new FilterParameters { TotalPopulationMin = 1527188425, ClientsMin = 1755309150, PotentialMin = 101075165, MaleDensity = "TestValue214596601", KidDensity = "TestValue2047113409", WorkAgeDensity = "TestValue260701745", ElderlyDensity = "TestValue1127019029", Penetration = "TestValue1112010648", PenetrationBin = "TestValue1463793686" };
            List<Polygon1km> polygonList = new List<Polygon1km>()
            {
                new Polygon1km(),
            };

            _regionLogicMock.Setup(x => x.FilterPolygonList(novadsId, pagastsId, It.IsAny<FilterParameters>()))
                .Returns(polygonList);

            var result = _target.FilterPolygonList(novadsId, pagastsId, filterParams);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(OkObjectResult)));
            Assert.That((result as ObjectResult).Value, Is.EqualTo(polygonList));
        }

        [Test]
        public void CannotCallFilterPolygonListWithNegativeTotalPopulation()
        {
            var novadsId = 1922425146;
            var pagastsId = 903026255;
            var filterParams = new FilterParameters { TotalPopulationMin = -123 };
            List<Polygon1km> polygonList = new List<Polygon1km>()
            {
                new Polygon1km(),
            };

            _regionLogicMock.Setup(x => x.FilterPolygonList(novadsId, pagastsId, It.IsAny<FilterParameters>()))
                .Returns(polygonList);

            var result = _target.FilterPolygonList(novadsId, pagastsId, filterParams);

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.AssignableFrom(typeof(BadRequestObjectResult)));
        }
    }
}