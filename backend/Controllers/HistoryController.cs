using LotteryBackend.Models;
using LotteryBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryBackend.Controllers
{
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
    }
}
