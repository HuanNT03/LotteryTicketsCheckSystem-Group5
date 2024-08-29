using LotteryBackend.Models;

namespace LotteryBackend.Services
{
    public interface IHistoryService
    {
        Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(int userId);
        Task AddHistoryAsync(CheckHistory history);
    }
}
