using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Customer.Controllers {

    [Route("api/customer")] // Customer endpoint
    [ApiController]

    public class CustomerController : ControllerBase
    {
         private readonly MainContext _context;
         
         public CustomerController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerItems>>> GetCustomers()
        {
            return await _context.customers.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<CustomerItems>> GetCustomers(int id)
        {
            var CustomerItems = await _context.customers.FindAsync(id);

            if (CustomerItems == null)
            {
                return NotFound();               // We can GET customer data with it's ID
            }

            return CustomerItems;
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, CustomerItems customerItems)
        {
            if (id != customerItems.id)
            {
                return BadRequest();
            }

            _context.Entry(customerItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(customerItems); // This is where we set our put method, you can add customers 
                                        // to the database through postman.
        }


        private bool CustomerExists(int id)
        {
            return _context.customers.Any(e => e.id == id);
        }

    }

}