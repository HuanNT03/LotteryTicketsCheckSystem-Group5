using LotteryBackend.Models;

public interface IHistoryService
{
    Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId);
    Task AddHistoryAsync(CheckHistory history);
}
