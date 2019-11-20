using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers {

    [Route ("api/quote")] // quote endpoint
    [ApiController]

    public class QuotesController : ControllerBase {
        private readonly MainContext _context;

        public QuotesController (MainContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuoteItems>>> GetQuotes () {
            return await _context.quotes.ToListAsync ();
        }

        private bool QuoteExists (int id) {
            return _context.quotes.Any (e => e.id == id);  // We can GET Quotes data with it's ID
        }
    }
}