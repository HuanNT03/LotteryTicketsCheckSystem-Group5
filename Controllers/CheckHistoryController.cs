using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CheckHistoryController : ControllerBase
{
    private readonly CheckHistoryService _checkHistoryService;

    public CheckHistoryController(CheckHistoryService checkHistoryService)
    {
        _checkHistoryService = checkHistoryService;
    }

    //[Authorize(Roles = "User")]
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetCheckHistoriesByUserId(int userId)
    {
        var checkHistories = await _checkHistoryService.GetCheckHistoriesByUserId(userId);

        if (checkHistories == null || !checkHistories.Any())
        {
            return NotFound("No check histories found for the given user.");
        }

        var result = checkHistories.Select(ch => new
        {
            ch.CH_Id,
            ch.CheckDate,
            ch.Result,
            ch.Comment,
            ch.LotteryTicketId
        });

        return Ok(result);
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> GetCheckHistories()
    {
        var checkHistories = await _checkHistoryService.GetAllCheckHistories();
        return Ok(checkHistories);
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCheckHistory(int id)
    {
        var checkHistory = await _checkHistoryService.GetCheckHistoryById(id);
        if (checkHistory == null) return NotFound();
        return Ok(checkHistory);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> CreateCheckHistory([FromBody] CheckHistory checkHistory)
    {
        await _checkHistoryService.AddCheckHistory(checkHistory);
        return CreatedAtAction(nameof(GetCheckHistory), new { id = checkHistory.CH_Id }, checkHistory);
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCheckHistory(int id, [FromBody] CheckHistory checkHistory)
    {
        if (id != checkHistory.CH_Id) return BadRequest();
        await _checkHistoryService.UpdateCheckHistory(checkHistory);
        return NoContent();
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCheckHistory(int id)
    {
        await _checkHistoryService.DeleteCheckHistory(id);
        return NoContent();
    }
}

