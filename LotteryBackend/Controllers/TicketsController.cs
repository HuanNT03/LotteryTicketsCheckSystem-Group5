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

    [HttpGet]
    public async Task<IActionResult> GetAllTicketsPaginated(int pageNumber = 1, int pageSize = 10)
    {
        var tickets = await _ticketService.GetAllLotteryTicketsAsync(pageNumber, pageSize);
        return Ok(tickets);
    }

    [HttpGet("search-by-company-and-date")]
    public async Task<IActionResult> SearchByCompanyAndDateRange(int companyId, DateTime fromDate, DateTime toDate)
    {
        var tickets = await _ticketService.GetTicketsByCompanyAndDateRangeAsync(companyId, fromDate, toDate);
        return Ok(tickets);
    }


    [HttpPut("{id}/publish")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] bool publish)
    {
        await _ticketService.UpdateTicketStatusAsync(id, publish);
        return NoContent();
    }

    [HttpGet("{id}/check-count")]
    public async Task<IActionResult> GetCheckCount(int id)
    {
        var count = await _ticketService.GetCheckCountByTicketIdAsync(id);
        return Ok(count);
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
            LotteryDate = ticketDto.LotteryDate,
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