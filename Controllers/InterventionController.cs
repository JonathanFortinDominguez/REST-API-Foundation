using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Intervention.Controllers {

    [Route("api/intervention")] 
    [ApiController]

    public class InterventionsController : ControllerBase
    {
         private readonly MainContext _context;
         
         public InterventionsController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<InterventionItems>>> GetInterventions()
        {
            return await _context.interventions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InterventionItems>> GetInterventions(int id)
        {
            var interventionItems = await _context.interventions.FindAsync(id);

            if (interventionItems == null)
            {
                return NotFound();
            }
        
            return interventionItems;  // GET method to fetch Interventions data with ID
        } 


        [HttpGet("status")]
       public IEnumerable<InterventionItems> GetIntervention()
       {
           // Using IQueryable, find all Intervention with status inactive or intervention
           IQueryable<InterventionItems> status = from intStatus in _context.interventions where intStatus.status == "Pending" || intStatus.intervention_datetime_start == null select intStatus;
           return status;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, InterventionItems interventionItems)
        {
            if (id != interventionItems.id)
            {
                return BadRequest();
            }

            _context.Entry(interventionItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InterventionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(interventionItems);      
        }

        [HttpPut("begin/{id}")]

        public string beginintervention(int id)
        {
            var intervention = _context.interventions.Find(id);
            intervention.status = "In Progress";
            intervention.intervention_datetime_start = DateTime.Now;
            _context.interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is now in progress";
        }

        [HttpPut("end/{id}")]

        public string endintervention(int id)
        {
            var intervention = _context.interventions.Find(id);
            intervention.result = "Completed";
            intervention.status = "Completed";
            intervention.intervention_datetime_end = DateTime.Now;
            _context.interventions.Update(intervention);
            _context.SaveChanges();
            return "Intervention is completed";
        }
        private bool InterventionExists(int id)
        {
            return _context.interventions.Any(e => e.id == id);
        }

    }

}