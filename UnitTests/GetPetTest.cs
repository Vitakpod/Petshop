using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Petshop.DAL.Entities;
using Petshop.DAL.Interfaces;
using Petshop.BLL.Services;

namespace UnitTests
{
    [TestClass]
    public class GetPetTest
    {
        [TestMethod]
        public void PetIdIsNull()
        {
            var mock = new Mock<IUnitOfWork>();
            ShopService service = new ShopService(mock.Object);
            Assert.ThrowsException<System.ArgumentNullException>(() => service.GetPet(null));
        }

        [TestMethod]
        public void PetIsNotFound()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(a => a.Pets.Get(1)).Returns((Pet)null);
            ShopService service = new ShopService(mock.Object);
            Assert.ThrowsException<System.InvalidOperationException>(() => service.GetPet(1));
        }
    }
}
