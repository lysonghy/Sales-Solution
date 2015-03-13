using Sales.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Core
{
    public class ContextManager
    {
        public static DbContext CreateContext { get{
            return new SalesOrderContext();
        }}
    }
}
