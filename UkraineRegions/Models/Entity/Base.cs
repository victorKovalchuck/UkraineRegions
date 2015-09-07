using LINQtoCSV;

namespace UkraineRegions.Models.Entity
{
    public class Base
    {
        [CsvColumn(FieldIndex = 1, Name = "Id")]
        public int Id { get; set; }
    }
}