using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Elevator.Controllers {

    [Route("api/elevatorstatus")]
    [ApiController]

    public class ElevatorStatusController : ControllerBase
    {
         private readonly MainContext _context;
         
         public ElevatorStatusController(MainContext context)
        {
            _context = context;
        }

        [HttpGet]
        // https://stackoverflow.com/questions/1578778/using-iqueryable-with-linq
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)

        public IEnumerable<ElevatorItems> GetElevators()
        {
            // Using IQueryable, we can find all elevators with status set to inactive or intervention
            IQueryable<ElevatorItems> status = from elevStatus in _context.elevators where elevStatus.status == "Inactive" || elevStatus.status == "Intervention" select elevStatus;
            
            return status;
        }

        [HttpGet("intervention")]
        // https://stackoverflow.com/questions/1578778/using-iqueryable-with-linq
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)

        public IEnumerable<ElevatorItems> GetInterventionElevators()
        {
            // Using IQueryable, we can find all elevators with status set to inactive or intervention
            IQueryable<ElevatorItems> status = from elevStatus in _context.elevators where elevStatus.status == "Intervention" select elevStatus;
            
            return status;
        }

        [HttpGet("inactive")]
        // https://stackoverflow.com/questions/1578778/using-iqueryable-with-linq
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)

        public IEnumerable<ElevatorItems> GetInactiveElevators()
        {
            // Using IQueryable, we can find all elevators with status set to inactive or intervention
            IQueryable<ElevatorItems> status = from elevStatus in _context.elevators where elevStatus.status == "Inactive" select elevStatus;
            
            return status;
        }

        [HttpGet("active")]
        // https://stackoverflow.com/questions/1578778/using-iqueryable-with-linq
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)

        public IEnumerable<ElevatorItems> GetActiveElevators()
        {
            // Using IQueryable, we can find all elevators with status set to inactive or intervention
            IQueryable<ElevatorItems> status = from elevStatus in _context.elevators where elevStatus.status == "Active" select elevStatus;
            
            return status;
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


//          [HttpPut("{id}")]
//         public async Task<IActionResult> PutTodoItem(int id, ElevatorItems elevatorItems)
//         {
//             if (id != elevatorItems.id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(elevatorItems).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!ElevatorExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }


//         private bool ElevatorExists(int id)
//         {
//             return _context.elevators.Any(e => e.id == id);
//         }

    }

}