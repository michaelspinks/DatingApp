using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // view in MVC comes from Angular
        // Users Controller derived from ControllerBase

        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = _context.Users.ToList();

            return users;
            // Could have used a list rather than IEnumerable
            // But IENumerable is simpler and more appropriate
            // Where we are not doing manipulation of the data
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            return _context.Users.Find(id);

            // If we aren't doing anything with the information we can just return the context
            // otherwise use a var
        }

    }
}