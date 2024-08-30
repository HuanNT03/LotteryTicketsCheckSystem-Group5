using LotteryBackend.Models;

public interface IHistoryService
{
    Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(string userId);
    Task AddHistoryAsync(CheckHistory history);
}
