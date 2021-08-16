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
    public class AdminTablesController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public AdminTablesController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/AdminTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminTable>>> GetAdminTables()
        {
            return await _context.AdminTables.ToListAsync();
        }

        // GET: api/AdminTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminTable>> GetAdminTable(int id)
        {
            var adminTable = await _context.AdminTables.FindAsync(id);

            if (adminTable == null)
            {
                return NotFound();
            }

            return adminTable;
        }

        // PUT: api/AdminTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminTable(int id, AdminTable adminTable)
        {
            if (id != adminTable.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminTableExists(id))
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

        // POST: api/AdminTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminTable>> PostAdminTable(AdminTable adminTable)
        {
            _context.AdminTables.Add(adminTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminTable", new { id = adminTable.AdminId }, adminTable);
        }

        // DELETE: api/AdminTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminTable(int id)
        {
            var adminTable = await _context.AdminTables.FindAsync(id);
            if (adminTable == null)
            {
                return NotFound();
            }

            _context.AdminTables.Remove(adminTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminTableExists(int id)
        {
            return _context.AdminTables.Any(e => e.AdminId == id);
        }
    }
}
