using LotteryBackend.Models;

public interface ILotteryService
{
    Task<LotteryResult> GetLotteryResultByDateAsync(DateTime date);
    Task AddLotteryResultAsync(LotteryResult result);
    Task<IEnumerable<LotteryResult>> GetResultsByTicketIdAsync(int ticketId);
    Task<LotteryResult> CheckLotteryNumberAsync(int ticketId, string number);
}
