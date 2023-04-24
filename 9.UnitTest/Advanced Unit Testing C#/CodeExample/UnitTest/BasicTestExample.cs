using API.Models.Entities;
using API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    //el nombre de la clase sería OrderServiceTest
    //la idea sería testear todos los métodos de OrderService aquí
    //aunque sin Mocks no se va a poder testear todo
    public class BasicTestExample
    {
        [TestMethod]
        public void ValidateOrderTest()
        {
            //Arrange
            var orderA = new OrderItem();
            orderA.Id = 1;
            orderA.IdBuyer = 3;
            orderA.IdProduct = 6;
            orderA.ProductAmount = 34;
            orderA.TotalPrice = 1000;
            orderA.IsPayed = false;
            orderA.IsDelivered = false;
            orderA.IsActive = true;
            orderA.InsertDate = DateTime.Now.AddDays(-1);
            orderA.UpdateDate = null;

            var orderB = new OrderItem();
            orderB.Id = 1;
            orderB.IdBuyer = -3;
            orderB.IdProduct = 6;
            orderB.ProductAmount = 34;
            orderB.TotalPrice = 1000;
            orderB.IsPayed = false;
            orderB.IsDelivered = false;
            orderB.IsActive = true;
            orderB.InsertDate = DateTime.Now.AddDays(-1);
            orderB.UpdateDate = null;

            var orderC = new OrderItem();
            orderC.Id = 1;
            orderC.IdBuyer = -3;
            orderC.IdProduct = 6;
            orderC.ProductAmount = 34;
            orderC.TotalPrice = 1000;
            orderC.IsPayed = false;
            orderC.IsDelivered = false;
            orderC.IsActive = true;
            orderC.InsertDate = DateTime.Now.AddDays(1);
            orderC.UpdateDate = null;

            //Act
            var isValidA = OrderService.ValidateOrderA(orderA);
            var isValidB = OrderService.ValidateOrderA(orderB);
            var isValidC = OrderService.ValidateOrderA(orderC);

            //Assert
            Assert.AreEqual(true, isValidA, "Custom error message");
            Assert.AreEqual(false, isValidB, "Custom error message");
            Assert.AreEqual(false, isValidC, "Custom error message");
        }
    }
}
