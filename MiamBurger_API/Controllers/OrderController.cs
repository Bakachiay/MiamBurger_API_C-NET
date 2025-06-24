using MiamBurger.Model;
using MiamBurger_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MiamBurger_API.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
       

        [HttpGet]
        public ActionResult<List<Order>> GetOrders() => OrderService.GetOrders();

        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            Order orderToReturn = OrderService.GetById(id);

            if (orderToReturn is null)
                return NotFound();

            return orderToReturn;
        }

        [HttpGet("beforeFebuary")]
        public ActionResult<List<Order>> GetBeforeFebruary()
        {
            List<Order> ordersToReturn = OrderService.GetBeforeFebruary();
            return ordersToReturn;
        }

        [HttpGet("last7Days")]
        public ActionResult<List<Order>> GetLast7Days()
        {
            List<Order> ordersToReturn = OrderService.GetLast7Days();

            return ordersToReturn;
        }

        [HttpPut("{id}")] //Je reçois l'id du burger à modifier + la version modifiée du burger
        public ActionResult Update(int id, Order updatedOrder)
        {
            if (id != updatedOrder.Number)
                return BadRequest();

            Order orderToUpdate = OrderService.GetById(id);

            if (orderToUpdate is null)
                return NotFound();

            try
            {
                OrderService.Update(updatedOrder);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
                return NotFound();
            }



            return NoContent();
        }

        [HttpPost]
        public ActionResult Create(Order order)
        {
            OrderService.Create(order);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                OrderService.Delete(id);
            }
            catch(InvalidOperationException ex)
            {
                return NotFound();
                Debug.WriteLine(ex.Message);
            }
            

            return NoContent();
        }
    }
}
