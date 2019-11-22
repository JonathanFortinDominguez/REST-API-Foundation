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

        [HttpGet("lastmonth")]
       // https://docs.microsoft.com/en-us/dotnet/csharp/linq/query-expression-basics (How to make query to database using IQueryable)
        public IEnumerable<QuoteItems> GetQuotesLastMonth()
        {
            double ts = -30;
           
            //https://stackoverflow.com/questions/17799499/cannot-convert-lambda-expression-to-delegate-type (Lambda operator)
            // This is how we can fetch all the leads that wasn't yet linked to a customer in the last 30 days.
            // We confirm that no customer is linked to lead because the ID is set to null

            IQueryable<QuoteItems> last = from last30 in _context.quotes
             where last30.created_at >= DateTime.Now.AddDays(ts)
             select last30;
         
            return last;

        }

        private bool QuoteExists (int id) {
            return _context.quotes.Any (e => e.id == id);  // We can GET Quotes data with it's ID
        }
    }
}