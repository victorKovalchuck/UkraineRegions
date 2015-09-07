using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UkraineRegions.Controllers;
using Moq;
using LINQtoCSV.CsvContextMockInterface;
using UkraineRegions.Models.Entity;
using System.Web.Mvc;
using System.Web;
using System.Web.Routing;
using UkraineRegions.PathHelper;
using System.IO;


namespace UkraineRegions.Tests
{
    [TestClass]
    public class HomeControllerTest
    {
        string pathActual;
        [TestInitialize]
        public void Init()
        {
            pathActual = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) + "\\UkraineRegions\\";
        
        }
        [TestMethod]
        public void RetriveRegionsDataTest()
        {
            List<Region> expectedList=new List<Region>();
            Region reg = new Region()
            {
                City="Kirovohrad",
                Population=200,
                Production="Oil"

            };
            expectedList.Add(reg);
            var mockCsvContext = new Mock<ICsvContext>();
            mockCsvContext
                .Setup(x => x.Read<Region>(It.IsAny<string>()))
                .Returns(expectedList);
            
            var httpRuntimeWrapper = new Mock<HttpRuntimeWrapper>();
            httpRuntimeWrapper.SetupGet(x => x.AppDomainAppVirtualPath).Returns(pathActual);
            DataPathHelper dataPathHelper = new DataPathHelper(httpRuntimeWrapper.Object);
            HomeController homeCntrl = new HomeController(mockCsvContext.Object);
            JsonResult result = homeCntrl.RetriveRegionsData() as JsonResult;
            List<Region> actualList = result.Data as List<Region>;

            CollectionAssert.AreEqual(actualList, expectedList);
        }


        [TestMethod]
        public void PathHelperTest()
        {  
            pathActual += "Data\\Region.csv";
            string pathExpected = DataPathHelper.GetDataPath("Region");
            Assert.AreEqual(pathActual, pathExpected);        
        }
    }
}
