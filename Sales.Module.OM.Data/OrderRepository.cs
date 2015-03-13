using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DAL.Common;
using Sales.Module.OM.Data.Interfaces;
using Sales.Module.OM.Data.Entities;
namespace Sales.Module.OM.Data
{
    public class OrderRepository : EF_BaseRepository<Guid, Order>, IOrderRepository
    {
    }
}
