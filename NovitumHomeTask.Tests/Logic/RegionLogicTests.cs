namespace NovitumHomeTask.Tests.Logic
{
    using NovitumHomeTask.Logic;
    using System;
    using NUnit.Framework;
    using NovitumHomeTask.DataAccess;
    using NovitumHomeTask.Model;

    [TestFixture]
    public class RegionLogicTests
    {
        private RegionLogic _testClass;
        private IRegionRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRegionRepository>();
            _testClass = new RegionLogic(_repository);
        }

        [Test]
        public void CanConstruct()
        {
            var instance = new RegionLogic(_repository);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void CannotConstructWithNullRepository()
        {
            Assert.Throws<ArgumentNullException>(() => new RegionLogic(default(IRegionRepository)));
        }

        [Test]
        public void CanCallFilterNovadsList()
        {
            var filterParams = new FilterParameters { TotalPopulationMin = 2003756328, MaleDensity = "TestValue23084989", KidDensity = "TestValue2104848890", WorkAgeDensity = "TestValue1345828306", ElderlyDensity = "TestValue2012692913", ClientsMin = 392223048, PotentialMin = 2021980101, Penetration = "TestValue10261493", PenetrationBin = "TestValue231750310" };
            var result = _testClass.FilterNovadsList(filterParams);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallFilterNovadsListWithNullFilterParams()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.FilterNovadsList(default(FilterParameters)));
        }

        [Test]
        public void CanCallFilterPagastsList()
        {
            var novadsId = 1472482545;
            var filterParams = new FilterParameters { TotalPopulationMin = 1163248405, MaleDensity = "TestValue920271442", KidDensity = "TestValue225948647", WorkAgeDensity = "TestValue750738519", ElderlyDensity = "TestValue1124683457", ClientsMin = 1767320727, PotentialMin = 639730102, Penetration = "TestValue1208836651", PenetrationBin = "TestValue345218673" };
            var result = _testClass.FilterPagastsList(novadsId, filterParams);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallFilterPagastsListWithNullFilterParams()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.FilterPagastsList(473182292, default(FilterParameters)));
        }

        [Test]
        public void CanCallFilterPolygonList()
        {
            var novadsId = 1272324116;
            var pagastsId = 246288763;
            var filterParams = new FilterParameters { TotalPopulationMin = 368246705, MaleDensity = "TestValue2107584677", KidDensity = "TestValue1706085249", WorkAgeDensity = "TestValue423140884", ElderlyDensity = "TestValue237896885", ClientsMin = 1717207775, PotentialMin = 1878865561, Penetration = "TestValue247038668", PenetrationBin = "TestValue2078635150" };
            var result = _testClass.FilterPolygonList(novadsId, pagastsId, filterParams);
            Assert.Fail("Create or modify test");
        }

        [Test]
        public void CannotCallFilterPolygonListWithNullFilterParams()
        {
            Assert.Throws<ArgumentNullException>(() => _testClass.FilterPolygonList(1996075429, 1964556456, default(FilterParameters)));
        }
    }
}