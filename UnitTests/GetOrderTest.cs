using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petshop.DAL.Entities;
using Petshop.DAL.Interfaces;
using Petshop.BLL.Services;

namespace UnitTests
{
    [TestClass]
    public class GetOrderTest
    {
        [TestMethod]
        public void OrderIdIsNull()
        {
            var mock = new Mock<IUnitOfWork>();
            ShopService service = new ShopService(mock.Object);
            Assert.ThrowsException<System.ArgumentNullException>(() => service.GetOrders(null));
        }


        [TestMethod]
        public void OrderIsNotFound()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Orders.Get(1)).Returns((Order)null);
            ShopService service = new ShopService(mock.Object);
            Assert.ThrowsException<System.InvalidOperationException>(() => service.GetOrders(1));
        }
    }
}
