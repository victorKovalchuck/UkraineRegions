using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LINQtoCSV;

namespace UkraineRegions.Models.Entity
{
    public class Region:Base
    {
        [CsvColumn(FieldIndex = 2, Name = "City")]
        public string City { get; set; }

        [CsvColumn(FieldIndex = 3, Name = "Regional Center")]
        public string RegionalCenter { get; set; }   

        [CsvColumn(FieldIndex = 4, Name = "Population")]
        public long Population { get; set; }

        [CsvColumn(FieldIndex = 5, Name = "Production")]
        public string Production { get; set; }
       
    }
}