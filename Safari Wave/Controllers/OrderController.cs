using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Safari_Wave.Models;
using Safari_Wave.Models.DTOs.Order;
using Safari_Wave.Repository.Interface;

namespace Safari_Wave.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet("Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var Orders = await orderService.GetOrders();
                return Ok(Orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("PlaceOrder")]
        public async Task<IActionResult> MakeOrder(MakeOrderDTO order)
        {
            try
            {
                var _order =await orderService.MakeanOrder(order);
                return Ok(_order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(int id,OrderUpdateDTO order)
        {
            try
            {
                var updateOrder = await orderService.UpdateOrder(id, order);
                return Ok(updateOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            try
            {
                var order = await orderService.GetOrderById(id);
                return Ok(order);
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("userorders")]
        public async Task<IActionResult>GetOrdersUser()
        {
            try
            {
                var currentUser = HttpContext.User.Identity.Name;
                var orders =await orderService.GetOrderByUser(currentUser);
                return Ok(orders);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
