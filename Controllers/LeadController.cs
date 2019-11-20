using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Lead.Controllers {

    [Route("api/lead")] // leads endpoint
    [ApiController]

    public class LeadsController : ControllerBase
    {
         private readonly MainContext _context;
         
         public LeadsController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<LeadItems>>> GetLeads()
        {
            return await _context.leads.ToListAsync();
        }

        [HttpGet("{lastmonth}")]
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)
        public IEnumerable<LeadItems> GetLead()
        {
            double ts = -30;
           

            //https://stackoverflow.com/questions/17799499/cannot-convert-lambda-expression-to-delegate-type (Lambda operator)
            // This is how we can fetch all the leads that wasn't yet linked to a customer in the last 30 days.
            // We confirm that no customer is linked to lead because the ID is set to null

            IQueryable<LeadItems> last = from last30 in _context.leads
             where last30.created_at >= DateTime.Now.AddDays(ts) && last30.customer_id == null
             select last30;

            
            return last;
            
        }

      [HttpPut("{id}")] // We can add a lead to the database through postman and the put method.
        public async Task<IActionResult> PutTodoItem(int id, LeadItems leadItems)
        {
            if (id != leadItems.id)
            {
                return BadRequest();
            }

            _context.Entry(leadItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(leadItems); // The code above will either create a new lead or update one. It also
                                  // confirms that a lead won't be posted twice.
        }


        private bool LeadExists(int id)
        {
            return _context.leads.Any(e => e.id == id); 
        }
  
    }

}