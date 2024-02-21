using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Models;
using OrdersAPI.Services;

namespace OrdersAPI.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;

        }
        [HttpGet]
        [Route("getorder")]
        public IActionResult GetOrderDetailsById(int orderId)
        {
            var retObj = _orderService.GetOrderDetailsById(orderId);
            return Ok(retObj);
        }
        [HttpGet]
        [Route("getallorders/{pageNumber}/{pageSize}")]
        public IActionResult GetAllOrders(int pageNumber, int pageSize)
        {
            var retObj = _orderService.GetAllOrders(pageNumber,pageSize);
            return Ok(retObj);
        }
        [HttpPost]
        [Route("processorder")]
        public IActionResult ProcessOrder(List<Order> order)
        {
            var retObj = _orderService.ProcessOrder(order);
            return Ok(retObj);
        }

    }
}
