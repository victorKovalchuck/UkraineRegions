using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LINQtoCSV.CsvContextMockInterface
{
    public interface ICsvContext
    {
        IEnumerable<T> Read<T>(string fileName) where T : class,new();
        void Write<T>(IEnumerable<T> enumeration, string fileName);
    }
}