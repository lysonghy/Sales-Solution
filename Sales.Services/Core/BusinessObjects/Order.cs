using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Services.Core.BusinessObjects
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Status { get; set; }
        public bool OnlineOrderFlag { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal OrderTotal { get; set; }
        public string CustomerName { get; set; }
        public IList<OrderItem> Items { get; set; }

    }
}
