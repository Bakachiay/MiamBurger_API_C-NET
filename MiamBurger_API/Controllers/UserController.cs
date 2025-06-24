using MiamBurger.Model;
using MiamBurger_API.Model;
using MiamBurger_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MiamBurger_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService _service;
        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult Create(User user)
        {

            _service.Create(user);

            return NoContent();
        }

        [HttpGet]
        public ActionResult<List<User>> ReadAll()
        {
            return _service.ReadAll();
        }

        [HttpGet("{id}")] //https://localhost:7001/User/4
        public ActionResult<User> Read(int id)
        {
            User user = _service.Read(id);

            //Si le burger n'existe pas => je retourne Not Found => Error 404
            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("name/{name}")] //https://localhost:7001/User/4
        public ActionResult<List<User>> ReadByName(string name)
        {
            List<User> users = _service.ReadByName(name);

            //Si le burger n'existe pas => je retourne Not Found => Error 404
            if (users is null)
            {
                return NotFound();
            }

            return users;
        }


        [HttpPut("{id}")] //Je reçois l'id du burger à modifier + la version modifiée du burger
        public ActionResult Update(int id, User updatedUser)
        {
            if (id != updatedUser.Number)
                return BadRequest();

            User userToUpdate = _service.Read(id);

            if (userToUpdate is null)
                return NotFound();


            _service.Update(updatedUser);

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
