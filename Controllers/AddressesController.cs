using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Address.Controllers {

    [Route("api/address")] // address endpoint
    [ApiController]

    public class AddressesController : ControllerBase
    {
         private readonly MainContext _context;
         
         public AddressesController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressItems>>> GetAddresses()
        {
            return await _context.addresses.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<AddressItems>> GetAddresses(int id)
        {
            var AddressItems = await _context.addresses.FindAsync(id);

            if (AddressItems == null)
            {
                return NotFound();
            }

            return AddressItems; // We can GET Addresses data with it's ID
        }
     
        [HttpGet("cities")]
        public ActionResult<List<string>> GetCities () {
         
           var cities = _context.addresses.Where(c => _context.buildings.Select(b => b.address_id).Contains(c.id)).Select(d=>d.city).Distinct().ToList();
            return cities;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, AddressItems addressItems)
        {
            if (id != addressItems.id)
            {
                return BadRequest();
            }

            _context.Entry(addressItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(addressItems);           // This is where we set our put method, you can add addresses 
                                                // to the database through postman.
        } 


        private bool AddressExists(int id)
        {
            return _context.addresses.Any(e => e.id == id);
        }

    }

}