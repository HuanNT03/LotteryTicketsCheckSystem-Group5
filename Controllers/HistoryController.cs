using LotteryBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryService _historyService;

    public HistoryController(IHistoryService historyService)
    {
        _historyService = historyService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetHistoryByUserId(int userId)
    {
        var history = await _historyService.GetHistoryByUserIdAsync(userId);
        return Ok(history);
    }

    [HttpPost]
    public async Task<IActionResult> AddHistory([FromBody] CheckHistoryDto historyDto)
    {
        var history = new CheckHistory
        {
            UserId = historyDto.UserId,
            TicketId = historyDto.TicketId,
            CheckDate = DateTime.Now,
            Result = historyDto.Result
        };

        await _historyService.AddHistoryAsync(history);
        return Ok();
    }
}