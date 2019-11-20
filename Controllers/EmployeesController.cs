using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers {

    [Route ("api/employee")] // employee endpoint
    [ApiController]

    public class EmployeesController : ControllerBase {
        private readonly MainContext _context;

        public EmployeesController (MainContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeItems>>> GetEmployees () {
            return await _context.employees.ToListAsync ();
        }

        private bool EmployeeExists (int id) {
            return _context.employees.Any (e => e.id == id);  // We can GET employees data with it's ID
        }
    }
}