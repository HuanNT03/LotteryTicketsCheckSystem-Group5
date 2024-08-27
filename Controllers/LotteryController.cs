using LotteryBackend.Models;
using LotteryBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryBackend.Controllers
{
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
            var result = await _lotteryService.GetResultByDateAsync(date);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("result")]
        public async Task<IActionResult> AddResult([FromBody] LotteryResult result)
        {
            await _lotteryService.AddResultAsync(result);
            return CreatedAtAction(nameof(GetResultByDate), new { date = result.LotteryDate }, result);
        }

        [HttpPut("result/{id}")]
        public async Task<IActionResult> UpdateResult(int id, [FromBody] LotteryResult updatedResult)
        {
            await _lotteryService.UpdateResultAsync(updatedResult);
            return NoContent();
        }

        [HttpDelete("result/{id}")]
        public async Task<IActionResult> DeleteResult(int id)
        {
            await _lotteryService.DeleteResultAsync(id);
            return NoContent();
        }
    }
}
