using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Battery.Controllers {

    [Route("api/battery")] // batteries endpoint.
    [ApiController]

    public class BatteriesController : ControllerBase
    {
         private readonly MainContext _context;
         
         public BatteriesController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<BatteryItems>>> GetBatteries()
        {
            return await _context.batteries.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<BatteryItems>> GetBatteries(int id)
        {
            var batteryItems = await _context.batteries.FindAsync(id);

            if (batteryItems == null)
            {
                return NotFound();
            }

            return batteryItems;  // GET method to fetch Batteries data with ID
        } 
            [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, BatteryItems batteryItems)
        {
            if (id != batteryItems.id)
            {
                return BadRequest();
            }

            _context.Entry(batteryItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BatteryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(batteryItems);        // You can create or update data through postman with this put method.
        }


        private bool BatteryExists(int id)
        {
            return _context.batteries.Any(e => e.id == id);
        }

    }

}