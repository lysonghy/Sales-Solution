using Sales.DataAccess.Core;
using Sales.DataAccess.Core.Entities;
using Sales.DataAccess.Repository;
using Sales.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Implementation
{
    public class OrderServices:IOrderServices
    {
        private IRepository<Sales.DataAccess.Core.Entities.Order, int> _orderRepo;
        public OrderServices()
        {
            _orderRepo = new EFRepository<Sales.DataAccess.Core.Entities.Order, int>();
        }
        private string GetStatus(int status) {
            switch (status)
            {
                case 1: return "Pending";
                case 2: return "Processing";
                case 3: return "Finished";
                case 4: return "Cancelled";
                default:
                    break;
            }
            return string.Empty;
        }
        public Core.BusinessObjects.Order GetOrder(int orderId)
        {
            var entity=_orderRepo.Get(orderId);
            return new Core.BusinessObjects.Order
            {
                OrderID = entity.OrderID,
                CustomerName = entity.Customer.LastName + " " + entity.Customer.FirstName,
                OnlineOrderFlag = entity.OnlineOrderFlag,
                OrderTotal = entity.OrderTotal,
                Status = GetStatus(entity.Status),
                SubTotal = entity.SubTotal,
                TaxAmt = entity.TaxAmt.Value,
                Items = entity.OrderItems.Select(p => new Core.BusinessObjects.OrderItem
                {
                    ProductID = p.ProductID,
                    ProductName = p.Product.Name,
                    Qty = p.OrderQty,
                    UnitPrice = p.UnitPrice,
                    Total = p.LineTotal,
                    Discount = p.UnitPriceDiscount.Value
                }).ToList()
            };
        }

        public IList<Core.BusinessObjects.Order> GetOrder(Core.BusinessObjects.OrderServicesRequest request)
        {
            throw new NotImplementedException();
        }

        public Core.BusinessObjects.OrderServicesResponse CreateOrder(Core.BusinessObjects.OrderServicesRequest request)
        {
            throw new NotImplementedException();
        }

        public Core.BusinessObjects.OrderServicesResponse UpdateOrder(Core.BusinessObjects.OrderServicesRequest request)
        {
            throw new NotImplementedException();
        }

        public Core.BusinessObjects.Invoice CreateInvoice(int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
