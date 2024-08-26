using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ILotteryResultRepository
    {
        Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date);
        Task AddLotteryResultAsync(LotteryResult result);
    }
}
