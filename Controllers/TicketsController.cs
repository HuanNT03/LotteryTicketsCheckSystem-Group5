using LotteryBackend.Models;
using Microsoft.AspNetCore.Mvc;

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
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> AddTicket([FromBody] TicketDto ticketDto)
    {
        var ticket = new Ticket
        {
            TicketNumber = ticketDto.TicketNumber,
            LotteryDate = ticketDto.LotteryDate,
            UserId = ticketDto.UserId
        };

        await _ticketService.AddTicketAsync(ticket);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketDto ticketDto)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }

        ticket.TicketNumber = ticketDto.TicketNumber;
        ticket.LotteryDate = ticketDto.LotteryDate;

        await _ticketService.UpdateTicketAsync(ticket);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        await _ticketService.DeleteTicketAsync(id);
        return NoContent();
    }
}