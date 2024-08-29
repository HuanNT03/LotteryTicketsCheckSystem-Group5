using LotteryBackend.Models;
using LotteryBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> AddTicket([FromBody] Ticket ticket)
        {
            var newTicket = await _ticketService.AddTicketAsync(ticket);
            return CreatedAtAction(nameof(GetTicket), new { id = newTicket.Id }, newTicket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket updatedTicket)
        {
            await _ticketService.UpdateTicketAsync(id, updatedTicket);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return NoContent();
        }
    }
}
