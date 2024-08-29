using LotteryBackend.Models;

namespace LotteryBackend.Services
{
    public interface ILotteryService
    {
        Task<LotteryResult?> GetResultByDateAsync(DateTime date);
        Task AddResultAsync(LotteryResult result);
        Task<IEnumerable<LotteryResult>> GetAllResultsAsync();
        Task UpdateResultAsync(LotteryResult result);
        Task DeleteResultAsync(int resultId);
    }
}
