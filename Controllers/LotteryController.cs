using Microsoft.AspNetCore.Authorization;
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

    [HttpPost("update-prize")]
    public async Task<IActionResult> UpdateTicketPrize([FromBody] UpdatePrizeDto dto)
    {
        await _lotteryService.UpdateTicketPrize(dto.TicketId, dto.Prize);
        return Ok();
    }

    // Endpoint để tạo vé số mới
    [HttpPost("create")]
    //[Authorize(Roles = "Admin")] // Chỉ admin mới có quyền tạo vé số
    public async Task<IActionResult> CreateLotteryTicket([FromBody] CreateLotteryTicketDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var ticket = new LotteryTicket
        {
            TicketNumber = dto.TicketNumber,
            IssueDate = dto.IssueDate,
            CompanyId = dto.CompanyId,
            Status = dto.Status
        };

        var createdTicket = await _lotteryService.CreateLotteryTicket(ticket);
        return CreatedAtAction(nameof(CreateLotteryTicket), new { id = createdTicket.TicketId }, createdTicket);
    }


    [HttpGet]
    public async Task<IActionResult> GetAllLotteryTickets()
    {
        var tickets = await _lotteryService.GetAllTickets();
        var result = tickets.Select(t => new LotteryTicketDto
        {
            TicketId = t.TicketId,
            TicketNumber = t.TicketNumber,
            IssueDate = t.IssueDate,
            CompanyName = t.LotteryCompany.CompanyName,
            Status = t.Status
        });

        return Ok(result);
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
