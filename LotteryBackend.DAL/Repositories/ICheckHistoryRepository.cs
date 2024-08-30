using LotteryBackend.Models;

namespace LotteryBackend.Repositories
{
    public interface ICheckHistoryRepository
    {
        Task<IEnumerable<CheckHistory>> GetHistoryByUserIdAsync(string userId);
        Task AddHistoryAsync(CheckHistory history);
    }
}
