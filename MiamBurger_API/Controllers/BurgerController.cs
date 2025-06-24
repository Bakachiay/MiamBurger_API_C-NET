using MiamBurger.Model;
using MiamBurger_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MiamBurger_API.Controllers
{

    [ApiController]

    //Défini la route pour accéder à ce controller
    //Retire le mot controller du nom de la classe => donc la route ici sera => Burger
    [Route("[controller]")]  

    //Hériter de ControllerBase pour un controller d'API
    public class BurgerController : ControllerBase
    {
        BurgerService _service;
        public BurgerController(BurgerService service)
        {
            _service = service;
        }

        [HttpGet] //https://localhost:7001/Burger
        public ActionResult<List<Burger>> GetAll() => _service.GetAll();


        [HttpGet("{id}")] //https://localhost:7001/Burger/4
        public ActionResult<Burger> GetById(int id)
        {
            //Je vais aller chercher dans la liste burgers celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            Burger burgerToReturn = _service.GetById(id);

            //Si le burger n'existe pas => je retourne Not Found => Error 404
            if (burgerToReturn is null)
            {
                return NotFound();
            }

            return burgerToReturn;
        }

        [HttpGet("name/{name}")] //https://localhost:7001/Burger/name/Classic%20Cheeseburger
        public ActionResult<Burger> GetByName(string name)
        {
            //Je vais aller chercher dans la liste burgers celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            Burger burgerToReturn = _service.GetByName(name);

            if (burgerToReturn is null)
            {
                return NotFound(); //Erreur 404
            }

            return burgerToReturn;
        }

        [HttpGet("minus10")] // https://localhost:7001/Burger/minus10
        public ActionResult<List<Burger>> GetMinus10()
        {
            List<Burger> burgersToReturn = _service.GetMinus10();

            return burgersToReturn;
        }

        [HttpGet("noPlaceHolder")] // https://localhost:7001/Burger/noPlaceHolder
        public ActionResult<List<Burger>> GetNoPlaceHolder()
        {
            List<Burger> burgersToReturn = _service.GetNoPlaceHolder();

            return burgersToReturn;
        }

        [HttpPost]
        public ActionResult Create(Burger burger)
        {
            try
            {
                _service.Create(burger);
            }
            catch(DbUpdateException ex)
            {
                Debug.WriteLine(ex.Message);
                return BadRequest();
            }
            

            return NoContent();
        }


        [HttpPut("{id}")] //Je reçois l'id du burger à modifier + la version modifiée du burger
        public ActionResult Update(int id, Burger updatedBurger)
        {
            if (id != updatedBurger.Number)
                return BadRequest();

            Burger burgerToUpdate = _service.GetById(id);

            if (burgerToUpdate is null)
                return NotFound();

            try
            {
                _service.Update(updatedBurger);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
                return NotFound();
            }
            


            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
             _service.Delete(id);

            return NoContent();
        }
    }
}
