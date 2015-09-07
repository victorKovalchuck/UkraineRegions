using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Policy;

namespace UkraineRegions.PathHelper
{
    public class DataPathHelper
    {
        static HttpRuntimeWrapper path = new HttpRuntimeWrapper();
        public DataPathHelper(HttpRuntimeWrapper pathForMock)
        {
            path = pathForMock;
           
        }
        public static string GetDataPath(string dataType)
        {
            string serverPath = GetServerPath();
            return string.Format("{0}Data\\{1}.csv", serverPath, dataType);

        }
        public static string GetServerPath()
        {
            return path.AppDomainAppVirtualPath;
        }
    }
}