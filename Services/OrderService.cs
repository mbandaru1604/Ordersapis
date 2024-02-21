using OrdersAPI.Models;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;


namespace OrdersAPI.Services
{
    public class OrderService : IOrderService
    {
        ILogger _logger;
        List<Order> orderList;
        public OrderService(ILogger<OrderService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> ProcessOrder(List<Order> orders)
        {



            orderList = new List<Order>();
            BlockingCollection<Order> blockingCollection = new BlockingCollection<Order>();
            _logger.LogInformation("Created blocking collection");
              Task producerThread = Task.Factory.StartNew(() =>
            {
                foreach (var item in orders)
                {
                    blockingCollection.Add(item);
                }
                blockingCollection.CompleteAdding();
            });
            _logger.LogInformation($"Blockingcollection count{blockingCollection.Count}");
            Task consumerThread = Task.Factory.StartNew(() =>
            {
                while (!blockingCollection.IsCompleted)
                {
                    Order item = blockingCollection.Take();
                    orderList.Add(item);
                }
            });
            Task.WaitAll(producerThread, consumerThread);

            _logger.LogInformation($"Order list processed");
            return true;
        }

        public Order GetOrderDetailsById(int orderId)
        {
            var orderList = GetInMemoryOrders();
            var order = orderList.FirstOrDefault(o => o.OrderId == orderId);
            return order;
        }
        public List<Order> GetAllOrders(int pageNumber, int pageSize)
        {
            var orderList = GetInMemoryOrders();
            var orders = orderList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return orders;
        }

        private List<Order> GetInMemoryOrders()
        {
            return new List<Order>
            {
                new Order{OrderId=1,OrderDate=DateTime.Now,ProductName="Bag",Quantity=1,price=500},
                new Order{OrderId=2,OrderDate=DateTime.Now,ProductName="Books",Quantity=2,price=1000},
                new Order{OrderId=3,OrderDate=DateTime.Now,ProductName="Pencils",Quantity=2,price=2000},
                new Order{OrderId=4,OrderDate=DateTime.Now,ProductName="Erasers",Quantity=2,price=3000}
            };
        }
    }
}
