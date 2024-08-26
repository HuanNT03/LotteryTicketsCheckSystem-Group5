using LotteryBackend.Models;

public interface ILotteryService
{
    Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date);
    Task AddLotteryResultAsync(LotteryResult result);
}
