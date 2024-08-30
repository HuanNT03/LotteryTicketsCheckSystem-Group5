using LotteryBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class LotteryResultController : ControllerBase
{
    private readonly ILotteryService _lotteryService;
    private readonly IHistoryService _historyService;

    public LotteryResultController(ILotteryService lotteryService, IHistoryService historyService)
    {
        _lotteryService = lotteryService;
        _historyService = historyService;
    }


    [HttpGet("{ticketId}/results")]
    public async Task<IActionResult> GetResults(int ticketId)
    {
        var results = await _lotteryService.GetResultsByTicketIdAsync(ticketId);
        return Ok(results);
    }


    [HttpPost("{ticketId}/check")]
    public async Task<IActionResult> CheckLotteryNumber(int ticketId, string number)
    {
        var result = await _lotteryService.CheckLotteryNumberAsync(ticketId, number);

        var userId = HttpContext.User.FindFirstValue("userID");

        //// Save check history
        var checkHistory = new CheckHistory
        {
            UserId = userId,
            TicketId = ticketId,
            CheckedNumber = number,
            Result = result != null ? $"Won: {result.PrizeCategory}" : "No win"
        };

        await _historyService.AddHistoryAsync(checkHistory);

        if (result == null)
        {
            return Ok("No winning numbers matched.");
        }
        return Ok($"You have won: {result.PrizeCategory}!");
    }

    [HttpGet("result/{date}")]
    public async Task<IActionResult> GetResultByDate(DateTime date)
    {
        var result = await _lotteryService.GetLotteryResultByDateAsync(date);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("result")]
    public async Task<IActionResult> AddResult([FromBody] LotteryResultDto resultDto)
    {
        var result = new LotteryResult
        {
            LotteryDate = resultDto.LotteryDate,
            WinningNumber = resultDto.WinningNumber
        };

        await _lotteryService.AddLotteryResultAsync(result);
        return Ok();
    }
}