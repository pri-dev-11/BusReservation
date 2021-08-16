using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusResrvation.Models;

namespace BusResrvation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusTablesController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public BusTablesController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/BusTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusTable>>> GetBusTables()
        {
            return await _context.BusTables.ToListAsync();
        }
        
         [HttpGet("{source}/{destination}/{doj}")]
        public async Task<ActionResult<IEnumerable<BusTable>>> GetSearchResult(string source, string destination, DateTime doj)
        {
            var busTable = await _context.BusTables.ToListAsync();
            List<BusTable> searchReasult = new List<BusTable>();
            foreach (BusTable bus in busTable)
            {
                if (bus.BusSource == source && bus.BusDestination == destination && bus.BusDateOfJourney == doj)
                {
                    searchReasult.Add(bus);
                }
            }
            if (searchReasult == null)
            {
                return NotFound();
            }
            return searchReasult;
        }

        // GET: api/BusTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusTable>> GetBusTable(int id)
        {
            var busTable = await _context.BusTables.FindAsync(id);

            if (busTable == null)
            {
                return NotFound();
            }

            return busTable;
        }

        // PUT: api/BusTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusTable(int id, BusTable busTable)
        {
            if (id != busTable.BusId)
            {
                return BadRequest();
            }

            _context.Entry(busTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BusTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusTable>> PostBusTable(BusTable busTable)
        {
            _context.BusTables.Add(busTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusTable", new { id = busTable.BusId }, busTable);
        }

        // DELETE: api/BusTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusTable(int id)
        {
            var busTable = await _context.BusTables.FindAsync(id);
            if (busTable == null)
            {
                return NotFound();
            }

            _context.BusTables.Remove(busTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusTableExists(int id)
        {
            return _context.BusTables.Any(e => e.BusId == id);
        }
    }
}
