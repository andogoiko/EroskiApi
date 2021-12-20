using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TxoskiApi.Models;

namespace TxoskiApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TxoskiTicketsController : ControllerBase
    {
        private readonly TxoskiTicketsContext _context;

        public TxoskiTicketsController(TxoskiTicketsContext context)
        {
            _context = context;
        }

        // GET: api/TxoskiTickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            return await _context.Ticket.ToListAsync();
        }

        // GET: api/TxoskiTickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(string id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/TxoskiTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(string id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {

                var seccionTicket = await _context.Ticket.FindAsync(id);

                seccionTicket.N_Ticket++;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // PUT: api/TxoskiTickets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("Reset/{id}")]
        public async Task<IActionResult> ResetTicket(string id)
        {
            var ticket = await _context.Ticket.FindAsync(id);

            if (ticket == null)
            {
                return NotFound();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {

                var seccionTicket = await _context.Ticket.FindAsync(id);

                seccionTicket.N_Ticket = 0;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
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

        // POST: api/TxoskiTickets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            _context.Ticket.Add(ticket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TicketExists(ticket.seccion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTicket", new { id = ticket.seccion }, ticket);
        }

        // DELETE: api/TxoskiTickets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(string id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(string id)
        {
            return _context.Ticket.Any(e => e.seccion == id);
        }
    }
}
