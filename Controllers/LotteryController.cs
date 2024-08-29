using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LotteryController : ControllerBase
{
    private readonly LotteryService _lotteryService;

    public LotteryController(LotteryService lotteryService)
    {
        _lotteryService = lotteryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTickets()
    {
        var tickets = await _lotteryService.GetAllTickets();
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        var ticket = await _lotteryService.GetTicketById(id);
        if (ticket == null) return NotFound();
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] LotteryTicket ticket)
    {
        await _lotteryService.AddTicket(ticket);
        return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(int id, [FromBody] LotteryTicket ticket)
    {
        if (id != ticket.TicketId) return BadRequest();
        await _lotteryService.UpdateTicket(ticket);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        await _lotteryService.DeleteTicket(id);
        return NoContent();
    }

    [HttpGet("search")]
    public async Task<IActionResult> GetTicketIdsByCompanyAndDate([FromQuery] string companyName, [FromQuery] DateTime issueDate)
    {
        var ticketIds = await _lotteryService.GetTicketIdsByCompanyAndDate(companyName, issueDate);
        if (!ticketIds.Any()) return NotFound("No tickets found for the given company and date.");
        return Ok(ticketIds);
    }
}
