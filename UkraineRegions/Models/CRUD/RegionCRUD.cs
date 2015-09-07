using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UkraineRegions.Models.Entity;
using LINQtoCSV;
using LINQtoCSV.CsvContextMockInterface;

namespace UkraineRegions.Models.CRUD
{
    public class RegionCRUD : BaseCRUD<Region>
    {
        public RegionCRUD(ICsvContext cc) : base() { _cc = cc; }

        ICsvContext _cc;

        public override List<Region> GetList()
        {         
            List<Region> regions = _cc.Read<Region>(FileName).ToList();
            return regions;
        }

        public override int Add(Region item)
        {
            if (item == null)
            {
                return 0;
            }

            List<Region> Regions = GetList();
            if (Regions == null)
            {
                Regions = new List<Region>();
            }

            int nextId = GetNextNumber();
            item.Id = nextId;
            Regions.Add(item);
            _cc.Write(Regions, FileName);
            return item.Id;
        }

        public override Region Get(int id)
        {
            Region region = GetList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return region;
        }

        public override void Update(Region item)
        {

            List<Region> regions = GetList();
            int index = GetList()
            .FindIndex(x => x.Id == item.Id);
            if (index != -1)
            {
                regions[index].City = item.City;
                regions[index].RegionalCenter = item.RegionalCenter;
                regions[index].Population = item.Population;
                regions[index].Production = item.Production;
                _cc.Write(regions, FileName);
            }           
        }

        public override void Delete(int id)
        {
            List<Region> regions = GetList();
            if (regions == null)
            {
                return;
            }
            Region region = regions.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (region == null || !region.Id.Equals(id))
            {
                return;
            }
            regions.Remove(region);
            _cc.Write(regions, FileName);
        }
    }
}