using LotteryBackend.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LotteryController : ControllerBase
{
    private readonly ILotteryService _lotteryService;

    public LotteryController(ILotteryService lotteryService)
    {
        _lotteryService = lotteryService;
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
            WinningNumbers = resultDto.WinningNumbers
        };

        await _lotteryService.AddLotteryResultAsync(result);
        return Ok();
    }
}