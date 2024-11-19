using Moq;
using Xunit;

namespace Testing_DotNet.Services.Testing.Unit_Testing
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task PlaceOrderAsync_Test_ShouldReturnTrue_WhenOrderIsSaved()
        {
            //create a mock class/interface/library
            var mockOrderRepository = new Mock<IOrderRepository>();
            
            //Setup mock behaviour
            mockOrderRepository
                   .Setup(repo=>repo.SaveOrderAsync(It.IsAny<Order>()))
                   .ReturnsAsync(true);            
            
            mockOrderRepository
                   .Setup(repo=>repo.GetOrderByIdAsync(It.IsAny<int>()))
                   .ReturnsAsync(new Order { Id = 1, ProductName = "product-1" });


            //send this mock repository/class/object
            var orderService = new OrderService(mockOrderRepository.Object);

            var order = new Order { Id = 5, ProductName = "Laptop" };
            //Act
            var result = await orderService.PlaceOrderAsync(order);

            Assert.True(result);

            //verify that the saveorderasync method was called once during the test
            mockOrderRepository.Verify(repo=>repo.SaveOrderAsync(order), Times.Once);
        }
    }
}
