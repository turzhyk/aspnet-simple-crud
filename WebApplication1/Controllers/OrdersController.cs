using Microsoft.AspNetCore.Mvc;
using OrderStore.Application.Services;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _service;
        public OrdersController(IOrdersService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<OrdersResponse>>> GetOrders()
        {
            var orders = await _service.GetAllOrders();
            var response = orders.Select(o => new OrdersResponse(o.Id, o.Descriprion, o.TotalPrice, o.AssignedTo));
            return Ok(response);
        }
    }
}
