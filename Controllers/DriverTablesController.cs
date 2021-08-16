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
    public class DriverTablesController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public DriverTablesController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/DriverTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverTable>>> GetDriverTables()
        {
            return await _context.DriverTables.ToListAsync();
        }

        // GET: api/DriverTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverTable>> GetDriverTable(int id)
        {
            var driverTable = await _context.DriverTables.FindAsync(id);

            if (driverTable == null)
            {
                return NotFound();
            }

            return driverTable;
        }

        // PUT: api/DriverTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverTable(int id, DriverTable driverTable)
        {
            if (id != driverTable.DriverId)
            {
                return BadRequest();
            }

            _context.Entry(driverTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverTableExists(id))
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

        // POST: api/DriverTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverTable>> PostDriverTable(DriverTable driverTable)
        {
            _context.DriverTables.Add(driverTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverTable", new { id = driverTable.DriverId }, driverTable);
        }

        // DELETE: api/DriverTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverTable(int id)
        {
            var driverTable = await _context.DriverTables.FindAsync(id);
            if (driverTable == null)
            {
                return NotFound();
            }

            _context.DriverTables.Remove(driverTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverTableExists(int id)
        {
            return _context.DriverTables.Any(e => e.DriverId == id);
        }
    }
}
