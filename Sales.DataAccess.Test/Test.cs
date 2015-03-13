using NUnit.Framework;
using Sales.DataAccess.Core;
using Sales.DataAccess.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sales.DataAccess.Repository;
namespace Sales.DataAccess.Test
{
    [TestFixture]
    public class Test
    {
        private IRepository<Order, int> _repoOrder;
      //  private const string _connectionString = "Data Source=SOHY-PC;Initial Catalog=SalesOrderDb;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public Test()
        {
            _repoOrder = new EFRepository<Order, int>();
        }
        [Test]
        public void GetPrimaryKeyValue()
        {
            var entity = _repoOrder.Get(1);
            Assert.AreEqual(1, _repoOrder.getPrimaryKeyValue(entity));
        }
        [Test]
        public void GetList() {
            var lst = _repoOrder.Get();
            //foreach (var item in lst)
            //{
            //    Console.WriteLine(item.OrderID + " " + item.OrderTotal);
            //}
            Assert.AreEqual(1, lst.Count());
         //   Assert.IsInstanceOfType(typeof(IQueryable<Order>), lst);
        }
        [Test]
        public void GetAndOrder()
        {
            var lst = _repoOrder.Get("SubTotal");
            Assert.IsNotNull(lst);
        }
    }
}
