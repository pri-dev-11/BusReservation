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
    public class ReservationTablesController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public ReservationTablesController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/ReservationTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationTable>>> GetReservationTables()
        {
            return await _context.ReservationTables.ToListAsync();
        }

        [HttpGet("GetByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<ReservationTable>>> GetUserReservationDetails(int userId)
        {
            var reservationTable = await _context.ReservationTables.ToListAsync();
            List<ReservationTable> userReservations = new List<ReservationTable>();
           
            foreach(ReservationTable res in reservationTable)
            {
                if (res.UserId == userId)
                {
                    userReservations.Add(res);
                }
            }
            if (userReservations == null)
            {
                return NotFound();
            }
            return userReservations;

        }
        // GET: api/ReservationTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationTable>> GetReservationTable(int id)
        {
            var reservationTable = await _context.ReservationTables.FindAsync(id);

            if (reservationTable == null)
            {
                return NotFound();
            }

            return reservationTable;
        }

        // PUT: api/ReservationTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservationTable(int id, ReservationTable reservationTable)
        {
            if (id != reservationTable.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(reservationTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationTableExists(id))
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

        // POST: api/ReservationTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservationTable>> PostReservationTable(ReservationTable reservationTable)
        {
            _context.ReservationTables.Add(reservationTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservationTable", new { id = reservationTable.TicketId }, reservationTable);
        }

        // DELETE: api/ReservationTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservationTable(int id)
        {
            var reservationTable = await _context.ReservationTables.FindAsync(id);
            if (reservationTable == null)
            {
                return NotFound();
            }

            _context.ReservationTables.Remove(reservationTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservationTableExists(int id)
        {
            return _context.ReservationTables.Any(e => e.TicketId == id);
        }
    }
}
