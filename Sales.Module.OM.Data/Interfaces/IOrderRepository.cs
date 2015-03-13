using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DAL.Common.Interfaces;
using Sales.Module.OM.Data.Entities;
namespace Sales.Module.OM.Data.Interfaces
{
    public interface IOrderRepository:Sales.DAL.Common.Interfaces.IBaseRepository<Guid,Order>
    {
    }
}
