using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantis1.src.Data;
using ayudantis1.src.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;

namespace ayudantis1.src.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            _context = context;
        }

        //metodos http

        //Gets

        [HttpGet]

        public IActionResult Get()
        {
            var users = _context.Users.Include(u => u.Role).ToList();
            return Ok(users);
        }

        
        [HttpGet("{id}")]

        public IActionResult GetById([FromRoute] int id)
        {
            var user = _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Id == id);

            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //Post
        [HttpPost]

        public IActionResult Post([FromBody] User user)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == user.RoleId);
            if (role == null)
            {
                return BadRequest("Role not found");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }

        //Actualizar
        [HttpPut("{id}")]

        public IActionResult Put([FromRoute] int id, [FromBody] User user)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == user.RoleId);

            if(role == null)
            {
                return BadRequest("Role not found");
            }

            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id);
            if(userToUpdate == null)
            {
                return NotFound();
            }

            userToUpdate.Rut = user.Rut;
            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;
            userToUpdate.RoleId = user.RoleId;

            _context.SaveChanges();
            return Ok(userToUpdate);
        }

        //Eliminar
        [HttpDelete("{id}")]

        public IActionResult Delete([FromRoute] int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }


    }
}