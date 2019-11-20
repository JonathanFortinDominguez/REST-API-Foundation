using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Building.Controllers {

    [Route("api/building")]
    [ApiController]

    public class BuildingStatusController : ControllerBase
    {
         private readonly MainContext _context;
         
         public BuildingStatusController(MainContext context)
        {
            _context = context;
        }


   [HttpGet]
        public async Task<ActionResult<IEnumerable<BuildingItems>>> GetElevators()
        {
            return await _context.buildings.ToListAsync();
        }


        //        [HttpGet("{id}")]
        // public async Task<ActionResult<BuildingItems>> GetBuildings(int id)
        // {
        //     var BuildingItems = await _context.buildings.FindAsync(id);

        //     if (BuildingItems == null)
        //     {
        //         return NotFound();
        //     }

        //     return BuildingItems;
        // }






        [HttpGet("status")]
        // https://stackoverflow.com/questions/1578778/using-iqueryable-with-linq
        public IEnumerable<BuildingItems> GetStatus()
        {
            // https://docs.microsoft.com/en-us/dotnet/api/system.linq.queryable?view=netframework-4.8

            // We need to use join clauses to join datas from 2 or more tables.
            // query to get building with at least one battery, column or elevator with intervention using IQueryable
            IQueryable<BuildingItems> status = (from buildingStatus in _context.buildings
             join batteryStatus in _context.batteries on buildingStatus.id equals batteryStatus.building_id
               join columnStatus in _context.columns on batteryStatus.id equals columnStatus.battery_id
                join elevatorStatus in _context.elevators on columnStatus.id equals elevatorStatus.column_id
                 where batteryStatus.status == "Intervention" || columnStatus.status == "Intervention" ||  
                 elevatorStatus.status == "Intervention"  select buildingStatus).Distinct();
            

            // IQueryable<BuildingItems> ss = (from building in _context.buildings
            // from battery in _context.batteries
            // from Column in _context.columns
            // from Elevator in _context.elevators
            // where battery.status == "Intervention" || Column.status == "Intervention" ||  
            //      Elevator.status == "Intervention"  select building).Distinct();
        

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