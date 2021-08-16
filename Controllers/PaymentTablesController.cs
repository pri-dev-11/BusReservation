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
    public class PaymentTablesController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public PaymentTablesController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTables
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentTable>>> GetPaymentTables()
        {
            return await _context.PaymentTables.ToListAsync();
        }

        // GET: api/PaymentTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentTable>> GetPaymentTable(int id)
        {
            var paymentTable = await _context.PaymentTables.FindAsync(id);

            if (paymentTable == null)
            {
                return NotFound();
            }

            return paymentTable;
        }

        // PUT: api/PaymentTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentTable(int id, PaymentTable paymentTable)
        {
            if (id != paymentTable.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(paymentTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTableExists(id))
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

        // POST: api/PaymentTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTable>> PostPaymentTable(PaymentTable paymentTable)
        {
            _context.PaymentTables.Add(paymentTable);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentTable", new { id = paymentTable.TransactionId }, paymentTable);
        }

        // DELETE: api/PaymentTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentTable(int id)
        {
            var paymentTable = await _context.PaymentTables.FindAsync(id);
            if (paymentTable == null)
            {
                return NotFound();
            }

            _context.PaymentTables.Remove(paymentTable);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymentTableExists(int id)
        {
            return _context.PaymentTables.Any(e => e.TransactionId == id);
        }
    }
}
