using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ILotteryResultRepository
    {
        Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date);

        Task<IEnumerable<LotteryResult>> GetResultsByTicketIdAsync(int ticketId);
        Task<LotteryResult> GetResultByTicketIdAndNumberAsync(int ticketId, string number);
        Task AddLotteryResultAsync(LotteryResult result);
    }
}
