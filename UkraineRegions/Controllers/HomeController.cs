using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UkraineRegions.Models.Entity;
using UkraineRegions.Models.CRUD;
using LINQtoCSV;
using LINQtoCSV.CsvContextMockInterface;

namespace UkraineRegions.Controllers
{
    public class HomeController : Controller
    {
        ICsvContext _csvContext;
        RegionCRUD regionCrud;
        public HomeController(ICsvContext csvContext)
        {
            this._csvContext = csvContext;
            regionCrud = new RegionCRUD(_csvContext);
        }

        public HomeController() : this(new CsvContext()) 
        {
            regionCrud = new RegionCRUD(_csvContext);
        }

        public ActionResult RetriveRegionsData()
        {
            List<Region> regions = regionCrud
                 .GetList();       

            return Json(regions, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Regions()
        {
            return View();
           
        }

        public ActionResult Default()
        {
            return View();
        }

        public ActionResult DeleteRegionData(int id)
        {
            regionCrud.Delete(id);
            return Json(null, JsonRequestBehavior.DenyGet);
        }
        
        public ActionResult EditRegionData(Region region)
        {
            regionCrud.Update(region);

            return Json(null, JsonRequestBehavior.DenyGet);
        }

        public ActionResult GetRegionData(int id)
        {
            Region region = regionCrud.Get(id);
            return Json(region, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveRegionData(Region region)
        {
            regionCrud.Add(region);
            return Json(null,JsonRequestBehavior.DenyGet);
        }

        public ActionResult EditRegion()
        {
            return View();
        }

        public ActionResult CreateRegion()
        {
            return View();
        }
    }
}
