using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Elevator.Controllers {

    [Route("api/elevator")] // elevator endpoint
    [ApiController]

    public class ElevatorsController : ControllerBase
    {
         private readonly MainContext _context;
         
         public ElevatorsController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<ElevatorItems>>> GetElevators()
        {
            return await _context.elevators.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<ElevatorItems>> GetElevators(int id)
        {
            var ElevatorItems = await _context.elevators.FindAsync(id);

            if (ElevatorItems == null)
            {
                return NotFound();
            }

            return ElevatorItems; // We can GET Elevators data with it's ID
        }

        //  [HttpGet("{status}")]
        // public async Task<ActionResult<ElevatorItems>> GetElevators(string status)
        // {
        //     var ElevatorItems = await _context.elevators.FindAsync(status);

        //     if (ElevatorItems == null)
        //     {
        //         return NotFound();
        //     }

        //     return ElevatorItems;
        // }


         [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, ElevatorItems elevatorItems)
        {
            if (id != elevatorItems.id)
            {
                return BadRequest();
            }

            _context.Entry(elevatorItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(elevatorItems);           // This is where we set our put method, you can add elevators 
                                                // to the database through postman.
        } 

        [HttpPut("updatestatus/{id}")]
        public async Task<IActionResult> PutElevatorStatus(long id, ElevatorStatus elevator)
        {

            if (id != elevator.id)
            {
                return BadRequest();
            }

            var current_elevator = _context.elevators.Find(elevator.id);
            current_elevator.status = elevator.status;

            if (elevator.status == "Intervention" || elevator.status == "Active" || elevator.status == "Inactive"){

                await _context.SaveChangesAsync();
                return NoContent();
            }

            else
            {
                return BadRequest();
            }
        }

        private bool ElevatorExists(int id)
        {
            return _context.elevators.Any(e => e.id == id);
        }

    }

}