using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.Services.Core;
namespace Sales.Services.Test
{
    [TestFixture]
    public class test
    {
        private IOrderServices _orderServices;
        public test()
        {
            _orderServices = new Implementation.OrderServices();
        }
        [Test]
        public void GetOrder() {
            var order = _orderServices.GetOrder(1);
            Assert.IsNotNull(order);
        }
    }
}
