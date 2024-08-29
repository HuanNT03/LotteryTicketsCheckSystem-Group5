using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ILotteryResultRepository
    {
        Task<LotteryResult> GetResultByDateAsync(DateTime date);
        Task AddResultAsync(LotteryResult result);
        Task<IEnumerable<LotteryResult>> GetAllResultsAsync();
        Task UpdateResultAsync(LotteryResult result);
        Task DeleteResultAsync(int resultId);
    }
}
