using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Repository;
using eCommerce.Models; 

namespace eCommerce.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDataRepository<User> _dataRep;
        public UserController(IDataRepository<User> dataRep)
        {
            _dataRep = dataRep;
        }

        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<User> users = _dataRep.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            User user = _dataRep.Get(id);
            if (user == null)
            {
                return NotFound("The User could't be found");
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            _dataRep.Add(user);
            return CreatedAtRoute(
                "Get",
                new { Id = user.Id },
                user);
        }

        [HttpPost("{id}")]
        public IActionResult Put(int id, User user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }
            User updatedUser = _dataRep.Get(id);
            if (updatedUser == null)
            {
                return NotFound("The user couldn't be found");
            }
            _dataRep.Update(updatedUser, user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _dataRep.Get(id); 
            if (user == null)
            {
                return NotFound("The user couldn't be found"); 
            }
            _dataRep.Delete(user);
            return NoContent(); 
        }
    }
}
