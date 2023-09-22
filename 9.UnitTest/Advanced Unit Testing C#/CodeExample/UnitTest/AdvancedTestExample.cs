using API.Data;
using API.IServices;
using API.Models.Entities;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using UnitTest.SampleData;

namespace UnitTest
{
    [TestClass]
    //el nombre de la clase sería OrderServiceTest
    //la idea sería testear todos los métodos de OrderService aquí
    public class AdvancedTestExample
    {
        private readonly OrderService _orderService;

        private List<OrderItem> AddedOrdersList = new List<OrderItem>();
        private int IdCounter = 0;

        public AdvancedTestExample()
        {
            var contextOptions = new DbContextOptions<ServiceContext>();
            var mockServiceContext = new Mock<ServiceContext>(contextOptions);
            var mockOrdersSet = new Mock<DbSet<OrderItem>>();
            var mockEmail = new Mock<IEmailService>();

            mockServiceContext.Setup(m => m.SaveChanges())
                                        .Callback(() =>
                                        {
                                            if (AddedOrdersList.Count > 0)
                                            {
                                                foreach (var order in AddedOrdersList)
                                                {
                                                    order.Id = IdCounter + 1;
                                                    IdCounter++;
                                                }
                                                AddedOrdersList = new List<OrderItem>();
                                            }
                                        });

            mockOrdersSet.Setup(m => m.Add(It.IsAny<OrderItem>()))
                                       .Callback((OrderItem orderItem) =>
                                       {
                                           AddedOrdersList.Add(orderItem);
                                       });

            mockEmail.Setup(m => m.SendNewOrderNotification(It.IsAny<OrderItem>()));

            var contextObject = mockServiceContext.Object;
            contextObject.Orders = mockOrdersSet.Object;
            _orderService = new OrderService(contextObject, mockEmail.Object);
        }
        [TestMethod]
        public void ValidateOrderTest()
        {
            //Arrange
            var validOrders = OrderSampleData.ValidOrdersData;
            var invalidOrders = OrderSampleData.InvalidOrdersData;

            //Act and Assert
            var counter = 1;
            foreach (var order in validOrders)
            {
                Assert.AreEqual(order.IsValid, _orderService.ValidateOrder(order), "Error en la iteración nro " + counter.ToString());
                counter++;
            }
            foreach (var order in invalidOrders)
            {
                Assert.AreEqual(order.IsValid, _orderService.ValidateOrder(order), "Error en la iteración nro " + counter.ToString());
                counter++;
            }
        }
    }
}
