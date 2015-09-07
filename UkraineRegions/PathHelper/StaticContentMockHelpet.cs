using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UkraineRegions.PathHelper
{
    public class HttpRuntimeWrapper
    {
        public virtual string AppDomainAppVirtualPath
        {
            get
            {
                return HttpRuntime.AppDomainAppPath;
            }
        }
    }
}