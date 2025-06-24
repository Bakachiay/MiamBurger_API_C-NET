using MiamBurger.Model;
using MiamBurger_API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MiamBurger_API.Controllers
{

    [ApiController]

    [Route("[controller]")]

    public class OrderLineController : ControllerBase
    {


        [HttpGet]
        public ActionResult<List<OrderLine>> GetAll() => OrderLineService.GetAll();


        //Un Get qui permet de récupérer toutes les lignes liées à une commande
        [HttpGet("Order/{id}")]
        public ActionResult<List<OrderLine>> GetByOrder(int id)
        {
            List<OrderLine> orderLinesToReturn = OrderLineService.GetByOrder(id);

            if (orderLinesToReturn.Count() == 0)
                return NotFound();

            return orderLinesToReturn;
        }


        //Un Get qui permet de récupérer toutes les lignes liées à un burger par l'id
        [HttpGet("Burger/{id}")]
        public ActionResult<List<OrderLine>> GetByBurger(int id)
        {
            List<OrderLine> orderLinesToReturn = OrderLineService.GetByBurger(id);

            if (orderLinesToReturn.Count() == 0)
                return NotFound();

            return orderLinesToReturn;
        }

        [HttpPost]
        public ActionResult Create(OrderLine orderLine)
        {
            OrderLineService.Create(orderLine);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                OrderLineService.Delete(id);
            }
            catch(InvalidOperationException ex)
            {
                return NotFound();
                Debug.WriteLine(ex.Message);
            }
            

            return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id,OrderLine updatedOrderLine)
        {
            if (id != updatedOrderLine.Number)
                return BadRequest();

            OrderLine orderLineToUpdate = OrderLineService.GetById(id);

            if (orderLineToUpdate is null)
                return NotFound();

            try
            {
                OrderLineService.Update(updatedOrderLine);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
                return NotFound();
            }
            return NoContent();
        }
    }
}
