using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Main.Models;

namespace Column.Controllers {

    [Route("api/column")] // Column endpoint
    [ApiController]

    public class ColumnsController : ControllerBase
    {
         private readonly MainContext _context;
         
         public ColumnsController(MainContext context)
        {
            _context = context;
        }

    [HttpGet]
        public async Task<ActionResult<IEnumerable<ColumnItems>>> GetColumns()
        {
            return await _context.columns.ToListAsync();
        }


         [HttpGet("{id}")]
        public async Task<ActionResult<ColumnItems>> GetColumns(int id)
        {
            var columnItems = await _context.columns.FindAsync(id);

            if (columnItems == null)
            {
                return NotFound();
            }

            return columnItems; // We can GET Columns data with it's ID
        }

         [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, ColumnItems columnItems)
        {
            if (id != columnItems.id)
            {
                return BadRequest();
            }

            _context.Entry(columnItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColumnExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(columnItems);     // This is where we set our put method, you can add columns
                                        // to the database through postman.
        }


        private bool ColumnExists(int id)
        {
            return _context.columns.Any(e => e.id == id);
        }

    }

}