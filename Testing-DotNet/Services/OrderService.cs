namespace Testing_DotNet.Services
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIdAsync(int orderId);
        Task<bool> SaveOrderAsync(Order order);
    }
    public class OrderService
    {
        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> PlaceOrderAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException(nameof(order));

            return await _repo.SaveOrderAsync(order);
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
    }



    //public class OrderRepository : IOrderRepository
    //{
    //    public List<Order> GetOrders()
    //    {
    //                    Order[] orders = {
    //                new Order{
    //                    Id = 1,
    //                ProductName = "product-1"
    //                },
    //               new Order{
    //                    Id = 2,
    //                ProductName = "product-2"
    //                },
    //                new Order{
    //                    Id = 3,
    //                ProductName = "product-3"
    //                }
    //                };

    //        return orders.ToList<Order>();

    //    }
    //    public async Task<Order> GetOrderByIdAsync(int orderId)
    //    {
    //        var orders = GetOrders();
    //        return orders.Find(x=>x.Id == orderId);
    //    }
    //}
}
