using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers {

    [Route ("api/user")] // user endpoint
    [ApiController]

    public class UsersController : ControllerBase {
        private readonly MainContext _context;

        public UsersController (MainContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserItems>>> GetUsers () {
            return await _context.users.ToListAsync ();
        }

        private bool UserExists (int id) {                 // We can GET User data with it's ID
            return _context.users.Any (e => e.id == id);
        }
    }
}