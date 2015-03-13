using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Services.Core.BusinessObjects;
namespace Sales.Services.Core
{
    public interface IOrderServices
    {
        Order GetOrder(int orderId);
        IList<Order> GetOrder(OrderServicesRequest request);
        OrderServicesResponse CreateOrder(OrderServicesRequest request);
        OrderServicesResponse UpdateOrder(OrderServicesRequest request);
        Invoice CreateInvoice(int orderId);
    }
}
