using OrdersAPI.Models;

namespace OrdersAPI.Services
{
    public interface IOrderService
    {
        Task<bool> ProcessOrder(List<Order> orders);
        Order GetOrderDetailsById(int orderId);
        List<Order> GetAllOrders(int pageNumber, int pageSize);
    }
}
